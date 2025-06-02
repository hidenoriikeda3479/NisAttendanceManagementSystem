using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Google.Apis.Drive.v2.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 時給一覧画面
    /// </summary>
    public partial class RankListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 時給IDを格納する変数
        /// </summary>
        int rankId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public RankListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームの初期処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RankListForm_Load(object sender, EventArgs e)
        {
            // 時給情報の表示
            GetRank();

            // カラム名の変更
            SetHeaderColumn();
        }

        /// <summary>
        /// データグリッドビューの設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRank_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 編集用テキストボックスに時給名を表示
            EditReflectRank();
        }

        /// <summary>
        /// 登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRank_Click(object sender, EventArgs e)
        {
            // 空白がある場合、処理を停止
            if (!CheckAddRank())
            {
                return;
            }

            // 空白以外かつ数字以外の入力の場合、処理を停止
            if (!CheckNumberRank())
            {
                return;
            }

            // 時給の新規登録処理
            RegisterRank();
        }

        /// <summary>
        /// 編集ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRank_Click(object sender, EventArgs e)
        {
            // 空白以外かつ数字以外の入力の場合、処理を停止
            if (!CheckNumberRank())
            {
                return;
            }

            // 時給名の編集処理
            EditRank();
        }

        /// <summary>
        /// 削除ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRank_Click(object sender, EventArgs e)
        {
            // 時給の削除処理
            DeleteRank();
        }

        /// <summary>
        /// フォームロード時に権時給のデータをすべて表示
        /// </summary>
        private void GetRank()
        {
            // Rankのデータを表示
            dgvRank.DataSource = _context.Ranks.ToList();
        }

        /// <summary>
        /// 選択された行を編集用のテキストボックスに反映する処理
        /// </summary>
        private void EditReflectRank()
        {
            // 選択された行があるか確認
            if (dgvRank.SelectedRows.Count > 0)
            {
                // 選択された時給のIDを取得する
                int rankId = (int)dgvRank.SelectedRows[0].Cells["RankId"].Value;

                // IDで時給を検索
                var rank = _context.Ranks.Where(a => a.RankId == rankId).Select(a => a.HourlyPay).SingleOrDefault();

                // オブジェクトを文字列に変換し、テキストボックスに表示する
                txtRank.Text = Convert.ToString(rank);
            }

            else
            {
                return;
            }
        }

        /// <summary>
        /// 時給の新規登録処理
        /// </summary>
        private void RegisterRank()
        {
            // 新しい時給データの作成
            var newRankData = new RankModel
            {
                HourlyPay = int.Parse(txtRank.Text), // 時給名
                CreatedAt = DateTime.Now,            // 作成日
            };

            // 同じ時給がある場合排除する処理
            var checkLinq = _context.Ranks.Select(c => c.HourlyPay).Distinct();

            // 同じ数字がある場合、処理を停止
            if (checkLinq.Contains(newRankData.HourlyPay))
            {
                MessageBox.Show("すでに同じ時給があります");
                return;
            }

            // 新しい時給データを追加
            _context.Ranks.Add(newRankData);

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい時給が追加されました。");

            // データグリッド再取得
            dgvRank.DataSource = _context.Ranks.ToList();
        }

        /// <summary>
        /// 登録のテキストボックスが空白の時
        /// </summary>
        private bool CheckAddRank()
        {
            if (string.IsNullOrEmpty(txtRank.Text))
            {
                MessageBox.Show("新しい時給を入力してください。");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 選択行された行の時給を編集する処理
        /// </summary>
        private void EditRank()
        {
            // 選択された行があるか確認
            if (dgvRank.SelectedRows.Count > 0)
            {
                // 空白がある場合、処理を停止
                if (string.IsNullOrEmpty(txtRank.Text))
                {
                    MessageBox.Show("編集する時給を入力してください。");
                    return;
                }

                // 選択されたの時給IDを取得
                rankId = (int)dgvRank.SelectedRows[0].Cells["RankId"].Value;

                // IDで時給を検索
                var rank = _context.Ranks.Single(a => a.RankId == rankId);

                // 時給情報を固定値で更新
                rank.HourlyPay = int.Parse(txtRank.Text);  // 時給名
                rank.UpdatedAt = DateTime.Now;             // 更新日

                // 権限が重複している文字列を排除する処理
                var checkLinq = _context.Ranks.Select(c => c.HourlyPay).Distinct();

                // 重複している文字れつがある場合、処理を停止
                if (checkLinq.Contains(rank.HourlyPay))
                {
                    MessageBox.Show("すでに同じ時給があります");
                    return;
                }

                // 編集したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新メッセージを表示
                MessageBox.Show("時給が更新されました。");

                // データグリッド再取得
                dgvRank.DataSource = _context.Ranks.ToList();
            }

            // 時給の選択がされていなかった時、メッセージを表示
            else
            {
                MessageBox.Show("編集する時給を選択してください。");
            }
        }

        /// <summary>
        /// 選択行された行の削除と再確認メッセージの表示
        /// </summary>
        private void DeleteRank()
        {
            // 選択されている行の確認
            if (dgvRank.SelectedRows.Count > 0)
            {
                // 削除の再確認のメッセージを表示
                DialogResult result = MessageBox.Show("本当に削除しますか？", "再確認メッセージ", MessageBoxButtons.YesNo);

                // 「Yes」を選択した場合、削除を行う
                if (result == DialogResult.Yes)
                {
                    // 選択された時給のIDを取得
                    int RankId = (int)dgvRank.SelectedRows[0].Cells["RankId"].Value;

                    // IDで時給を検索
                    var rank = _context.Ranks.First(n => n.RankId == RankId);

                    // 選択した行の削除
                    _context.Ranks.Remove(rank);

                    // 削除したデータをコミット
                    _context.SaveChanges();

                    // データグリッドを更新したメッセージを表示
                    MessageBox.Show("削除されました。");

                    // データグリッド再取得
                    dgvRank.DataSource = _context.Ranks.ToList();
                }

                //「NO」を選択した場合、処理をしない
                else if (result == DialogResult.No)
                {
                    return;
                }

                // 削除する時給が選択されてない場合、メッセージを表示   
            }
            else
            {
                MessageBox.Show("削除する時給を選択してください。");
            }
        }

        /// <summary>
        /// 時給のカラム名の変更する処理
        /// </summary>
        private void SetHeaderColumn()
        {
            // カラムの表示名の変更
            var cgId = dgvRank.Columns["RankId"];
            cgId.HeaderText = "ID";

            var cgHourlyPay = dgvRank.Columns["HourlyPay"];
            cgHourlyPay.HeaderText = "時給";

            var cgCreation = dgvRank.Columns["CreatedAt"];
            cgCreation.HeaderText = "作成日";

            var cgUpdate = dgvRank.Columns["UpdatedAt"];
            cgUpdate.HeaderText = "更新日";
        }

        /// <summary>
        /// 空白以外かつ、時給の入力が数字以外の場合に停止する処理
        /// </summary>
        /// <returns></returns>
        private bool CheckNumberRank()
        {
            // 時給に入力がある場合
            if (txtRank.Text != "")
            {
                int numberRank;

                // 入力値が数字かのチェック処理
                if (!int.TryParse(txtRank.Text, out numberRank))
                {
                    MessageBox.Show("数字を入力してください。");
                    return false;
                }
            }
            return true;
        }
    }
}
    

