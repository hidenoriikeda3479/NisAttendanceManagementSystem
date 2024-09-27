using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.Common;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 登録・更新画面
    /// </summary>
    public partial class EmployeeRegUpdate : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new ErrorProvider();

        int _employeeid; // 従業員IDを保存

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="employeeid">従業員ID</param>
        public EmployeeRegUpdate(AttendanceManagementDbContext context, int employeeid = 0)
        {
            InitializeComponent();
            _context = context; // DBコンテキスト
            _employeeid = employeeid; // 従業員ID

            // 現在の日付を最大の日付として設定
            dateTimePicker1.MaxDate = DateTime.Today;

            // employeeid が 0 より大きい場合、選択した従業員で更新画面を開く
            if (employeeid > 0)
            {
                var result = _context.Employees.Single(e => e.EmployeeId == employeeid);

                // 更新時のテキスト表記
                _employeeid = employeeid; // 従業員IDを保存
                txtName.Text = result.EmployeeName; // 従業員名
                txtPhone.Text = result.PhoneNumber; // 電話番号
                txtPost.Text = result.PostCode; // 郵便番号
                txtAddress.Text = result.Address; // 住所
                txtBuilding.Text = result.Address; // 建物名
            }

            // 押下時、画面表記変更イベント
            VisileEvent(employeeid);
        }

        #region ロード・表示

        /// <summary>
        /// 従業員登録・更新画面ロード
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void EmployeeUpdate_Load(object sender, EventArgs e)
        {
            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            cmbRank.SelectedIndex = 0; // ランク初期表示
            cmbShift.SelectedIndex = 0; // シフト初期表示

            // ランクの取得
            InitializeRanks();
        }

        #endregion

        #region clickイベント

        /// <summary>
        /// 登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            // ErrorProviderをクリア
            errorProvider.Clear();

            bool isInputValid = InputCheck(); // 空白エラーチェック
            bool isRegistrationValid = RegistrationCheck(); // ランクの選択チェック
            bool isPasswordValid = Passwordcheck(); // パスワードチェック

            // いずれかのチェックが失敗した場合、エラーメッセージを表示する
            if (!isInputValid || !isRegistrationValid || !isPasswordValid)
            {
                MessageBox.Show("必要な情報が入力、選択されていません。");
                return;
            }

            // ユーザー登録処理
            InsertDate();

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい従業員が追加されました。");

            this.Close();
        }

        /// <summary>
        /// 更新ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // ErrorProviderをクリアします。
            errorProvider.Clear();

            // ボタン押下時、空白エラーチェック
            if (!InputCheck())
            {
                MessageBox.Show("必要な情報が入力がされていません");
                return;
            }
            else
            {
                // 従業員更新処理
                UpdateDate();

                // 追加したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新して通知
                MessageBox.Show("従業員情報が更新されました。");

                // フォームを閉じる
                this.Close();
            }
        }

        /// <summary>
        /// 退社ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnLeaving_Click(object sender, EventArgs e)
        {
            // 退社ボタン押下時の確認メッセージ
            if (MessageBox.Show("退社ボタンが押されました。\r\n実行してよろしいでしょうか？", "確認",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int employeeId = _employeeid;

                // IDで従業員を検索
                var aemployee = _context.Employees.Single(n => n.EmployeeId == employeeId);

                if (aemployee != null && aemployee.ResignDate == null)
                {
                    // 現在の時間で退社する
                    aemployee.ResignDate = DateTime.Now;

                    // 追加したデータをコミット
                    _context.SaveChanges();

                    MessageBox.Show("退社しました。");

                    // フォームを閉じる
                    this.Close();
                }
                else
                {
                    MessageBox.Show("この従業員は既に退社済みです");
                }
            }
        }

        #endregion

        #region 従業員登録、更新処理

        /// <summary>
        /// 画面表記変更イベント
        /// </summary>
        /// <param name="visibleflag">フラグ固定値</param>
        private void VisileEvent(int visibleflag)
        {
            // 登録ボタン押下時、更新画面表記非表示
            if (visibleflag == 0)
            {
                labelUpdate.Visible = false;
                btnUpdate.Visible = false;
                btnLeaving.Visible = false;
            }
            // 更新ボタン押下時、登録表記非表示
            else
            {
                labelRegistration.Visible = false;
                btnRegistration.Visible = false;
                dateTimePicker1.Enabled = false;
                cmbRank.Enabled = false;
                cmbShift.Enabled = false;
                txtPswrd.Visible = false;
                labelPswrd.Visible = false;
                labelRePswrd.Visible = false;
                txtRepswrd.Visible = false;
            }
        }

        /// <summary>
        /// 従業員登録処理
        /// </summary>
        private void InsertDate()
        {
            // コンボボックスの選択されたランクIDを取得
            int selectedRankId = (int)((dynamic)cmbRank.SelectedItem).Value;

            // 新しい従業員データの作成
            var newEmployee = new EmployeeModel
            {
                EmployeeName = txtName.Text,
                Gender = menRadio.Checked ? 1 : 2,
                Password = HashHelper.Sha512(txtPswrd.Text),
                PhoneNumber = txtPhone.Text,
                PostCode = txtPost.Text,
                Address = txtAddress.Text,
                BuildingName = txtBuilding.Text,
                BirthDate = dateTimePicker1.Value,
                RankId = selectedRankId,
                HireDate = DateTime.Now,
                PermissionId = 2,
                CreatedAt = DateTime.Now,
            };

            // 新しい従業員データを追加
            _context.Employees.Add(newEmployee);
        }

        /// <summary>
        /// 従業員更新処理
        /// </summary>
        private void UpdateDate()
        {
            int employeeid = _employeeid;

            // IDで従業員を検索
            var employee = _context.Employees.Single(n => n.EmployeeId == employeeid);

            employee.EmployeeName = txtName.Text;
            employee.Gender = menRadio.Checked ? 1 : 2;
            employee.PhoneNumber = txtPhone.Text;
            employee.PostCode = txtPost.Text;
            employee.Address = txtAddress.Text;
            employee.BuildingName = txtBuilding.Text;
            employee.UpdatedAt = DateTime.Now;
        }

        #endregion

        #region 入力制限イベント

        /// <summary>
        /// テキスト入力確認イベント
        /// </summary>
        /// <returns>入力が正しい場合は true、入力が不足している場合は false を返す</returns>
        private bool InputCheck()
        {
            var flag = true;

            // 名前が入力されているか
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider.SetError(txtName, "名前を入力して下さい");
                flag = false;
            }

            // 郵便番号が入力されているか
            if (txtPost.Text.Length < 7)
            {
                errorProvider.SetError(txtPost, "郵便番号を入力して下さい");
                flag = false;
            }

            // 住所・番地が入力されているか
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, "住所・番地を入力して下さい");
                flag = false;
            }

            // 電話番号が入力されているか
            if (txtPhone.Text.Length < 10)
            {
                errorProvider.SetError(txtPhone, "電話番号を入力して下さい");
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// パスワード空白チェック
        /// <returns>入力が正しい場合は true、入力が不足している場合は false を返す</returns>
        private bool Passwordcheck()
        {
            var flag = true;

            // パスワードが６～１２文字で入力されているか
            if (txtPswrd.Text.Length < 6)
            {
                errorProvider.SetError(txtPswrd, "6～12文字で入力して下さい");
                flag = false;
            }
            else
            {
                // 大文字と小文字の含有チェック
                bool hasUpper = txtPswrd.Text.Any(char.IsUpper);
                bool hasLower = txtPswrd.Text.Any(char.IsLower);

                if (!hasUpper || !hasLower)
                {
                    errorProvider.SetError(txtPswrd, "大文字と小文字の両方を含めて下さい");
                    flag = false;
                }
                else
                {
                    // エラーメッセージをクリア
                    errorProvider.SetError(txtPswrd, "");
                }
            }

            // パスワード確認の合否
            if (txtPswrd.Text != txtRepswrd.Text)
            {
                errorProvider.SetError(txtRepswrd, "パスワードが同じではありません");
                flag = false;
            }
            else if (txtRepswrd.Text == "")
            {
                // パスワード入力されているか
                errorProvider.SetError(txtRepswrd, "パスワード入力して下さい");
                flag = false;
            }
            else
            {
                // エラーメッセージをクリア
                errorProvider.SetError(txtRepswrd, "");
            }
            return flag;
        }

        /// <summary>
        /// コンボボックス選択確認イベント
        /// </summary>
        /// <returns>入力が正しい場合は true、入力が不足している場合は false を返す</returns>
        private bool RegistrationCheck()
        {
            var flag = true;

            // ランクが選択されているか
            if (cmbRank.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbRank, "ランクを選択して下さい");
                flag = false;
            }

            // シフトが選択されているか
            if (cmbShift.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbShift, "シフトを選択して下さい");
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 数字以外入力不可とするイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            //バックスペースが押された時は有効（Deleteキーも有効）
            if (e.KeyChar == '\b')
            {
                return;
            }

            //押されたキーが 0～9でない場合は、イベントをキャンセルする
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// コンボボックスランク取得
        /// </summary>
        private void InitializeRanks()
        {
            // データベースからランクIDを取得
            var ranks = _context.Ranks.ToList();

            // コンボボックスのアイテムをクリア
            cmbRank.Items.Clear();

            // ヘッダーアイテムを追加
            cmbRank.Items.Add(new { Text = "選択して下さい", Value = 0 });

            // ランクIDの表示テキストを設定
            var rankNames = new Dictionary<int, string>
            {
                 { 1, "★1：1100円" },
                 { 2, "★2：1200円" },
                 { 3, "★3：1300円" },
                 { 4, "★4：1400円" },
                 { 5, "★5：1500円" }
            };

            // ランクをコンボボックスに追加
            foreach (var rank in ranks)
            {
                if (rankNames.ContainsKey(rank.RankId))
                {
                    cmbRank.Items.Add(new { Text = rankNames[rank.RankId], Value = rank.RankId });
                }
            }

            // デフォルトで最初のアイテムを選択する
            if (cmbRank.Items.Count > 0)
            {
                cmbRank.DisplayMember = "Text";
                cmbRank.ValueMember = "Value";
                cmbRank.SelectedIndex = 0;
            }
        }

        #endregion
    }
}
