using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Google.Apis.Drive.v2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 権限一覧画面
    /// </summary>
    public partial class PermissionListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 権限IDを格納する変数
        /// </summary>
        int permissionId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public PermissionListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームの初期処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PermissionListForm_Load(object sender, EventArgs e)
        {
            // 権限情報の表示
            GetPermission();

            // カラム名の変更
            SetHeaderColumn();
        }

        /// <summary>
        /// データグリッドビューの設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPermission_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 編集用テキストボックスに権限名を表示
            EditReflectPermission();
        }

        /// <summary>
        /// 登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 空白がある場合、処理を停止
            if (!CheckAddPermission())
            {
                return;
            }

            // 権限の新規登録処理
            RegisterPermission();
        }

        /// <summary>
        /// 編集ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 権限名の編集処理
            EditPermission();
        }

        /// <summary>
        /// 削除ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePermissions_Click(object sender, EventArgs e)
        {
            // 権限の削除処理
            DeletePermission();
        }

        /// <summary>
        /// フォームロード時に権限のデータをすべて表示
        /// </summary>
        private void GetPermission()
        {
            // 権限のデータを表示
            dgvPermission.DataSource = _context.Permissions.ToList();
        }

        /// <summary>
        /// 選択された行を編集用のテキストボックスに反映する処理
        /// </summary>
        private void EditReflectPermission()
        {
            // 選択された行があるか確認
            if (dgvPermission.SelectedRows.Count > 0)
            {
                // 選択された権限のIDを取得する
                int PermissionId = (int)dgvPermission.SelectedRows[0].Cells["PermissionId"].Value;

                // IDで権限を検索
                var permission = _context.Permissions.Where(n => n.PermissionId == PermissionId).Select(n => n.PermissionName).FirstOrDefault();

                // オブジェクトを文字列に変換し、テキストボックスに表示する
                txtPermission.Text = Convert.ToString(permission);
            }

            else
            {
                return;
            }
        }

        /// <summary>
        /// 権限の新規登録処理
        /// </summary>
        private void RegisterPermission()
        {
            // 新しい権限データの作成
            var newPermissionData = new PermissionModel
            {
                PermissionName = txtPermission.Text,    // 権限名
                CreatedAt = DateTime.Now,               // 作成日
            };

            // 権限が同じ文字列の場合排除する処理
            var checkLinq = _context.Permissions.Select(c => c.PermissionName).Distinct();

            // 同じ文字列がある場合、処理を停止
            if (checkLinq.Contains(newPermissionData.PermissionName))
            {
                MessageBox.Show("すでに同じ権限があります");
                return;
            }

            // 新しい権限データを追加
            _context.Permissions.Add(newPermissionData);

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい権限が追加されました。");

            // データグリッド再取得
            dgvPermission.DataSource = _context.Permissions.ToList();
        }

        /// <summary>
        /// 登録のテキストボックスが空白の時
        /// </summary>
        private bool CheckAddPermission()
        {
            if (string.IsNullOrEmpty(txtPermission.Text))
            {
                MessageBox.Show("新しい権限を入力してください。");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 選択行された行の権限を編集する処理
        /// </summary>
        private void EditPermission()
        {
            // 選択された行があるか確認
            if (dgvPermission.SelectedRows.Count > 0)
            {
                // 空白がある場合、処理を停止
                if (string.IsNullOrEmpty(txtPermission.Text))
                {
                    MessageBox.Show("編集する権限を入力してください。");
                    return;
                }

                // 選択されたの権限IDを取得
                permissionId = (int)dgvPermission.SelectedRows[0].Cells["PermissionId"].Value;

                // IDで権限を検索
                var permission = _context.Permissions.Single(a => a.PermissionId == permissionId);

                // 権限情報を固定値で更新
                permission.PermissionName = txtPermission.Text;  // 権限名
                permission.UpdatedAt = DateTime.Now;             // 更新日

                // 権限が同じ文字列の場合排除する処理
                var checkLinq = _context.Permissions.Select(c => c.PermissionName).Distinct();

                // 同じ文字列がある場合、処理を停止
                if (checkLinq.Contains(permission.PermissionName))
                {
                    MessageBox.Show("すでに同じ権限があります");
                    return;
                }

                // 編集したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新メッセージを表示
                MessageBox.Show("権限名が更新されました。");

                // データグリッド再取得
                dgvPermission.DataSource = _context.Permissions.ToList();
            }

            // 権限の選択がされていなかった時、メッセージを表示
            else
            {
                MessageBox.Show("編集する権限を選択してください。");
            }
        }

        /// <summary>
        /// 選択行された行の削除と再確認メッセージの表示
        /// </summary>
        private void DeletePermission()
        {
            // 選択されている行の確認
            if (dgvPermission.SelectedRows.Count > 0)
            {
                // 削除の再確認のメッセージを表示
                DialogResult result = MessageBox.Show("本当に削除しますか？", "再確認メッセージ", MessageBoxButtons.YesNo);

                // 「Yes」を選択した場合、削除を行う
                if (result == DialogResult.Yes)
                {
                    // 選択された権限のIDを取得
                    int PermissionId = (int)dgvPermission.SelectedRows[0].Cells["PermissionId"].Value;

                    // IDで権限を検索
                    var permission = _context.Permissions.First(n => n.PermissionId == PermissionId);

                    // 選択した行の削除
                    _context.Permissions.Remove(permission);

                    // 削除したデータをコミット
                    _context.SaveChanges();

                    // データグリッドを更新したメッセージを表示
                    MessageBox.Show("削除されました。");

                    // データグリッド再取得
                    dgvPermission.DataSource = _context.Permissions.ToList();
                }

                //「NO」を選択した場合、処理をしない
                else if (result == DialogResult.No)
                {
                    return;
                }

                // 削除する権限が選択されてない場合、メッセージを表示   
            }
            else
            {
                MessageBox.Show("削除する権限を選択してください。");
            }
        }

        /// <summary>
        /// 権限のカラム名の変更する処理
        /// </summary>
        private void SetHeaderColumn()
        {
            // カラムの表示名の変更
            var cgId = dgvPermission.Columns["PermissionId"];
            cgId.HeaderText = "ID";

            var cgName = dgvPermission.Columns["PermissionName"];
            cgName.HeaderText = "権限";

            var cgCreation = dgvPermission.Columns["CreatedAt"];
            cgCreation.HeaderText = "作成日";

            var cgUpdate = dgvPermission.Columns["UpdatedAt"];
            cgUpdate.HeaderText = "更新日";
        }
    }
}
