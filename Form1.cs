namespace BurgerKiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Ensure no menu radio is selected when the form is constructed
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            // Enable form-level key handling so we can implement keyboard navigation
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            // Pressing Enter should trigger the order button by default
            this.AcceptButton = btnOrder;

            // Define control groups used for keyboard navigation
            menuRadios = new Control[] { rdoHamBurger, rdoBulgogiBurger, rdoChickenBurger };
            optionChecks = new Control[] { chkPotato, chkCola, chkCheese, chkSauce };
            actionButtons = new Control[] { btnOrder, btninit };
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            chkPotato.Checked = false;
            chkCola.Checked = false;
            chkCheese.Checked = false;
            chkSauce.Checked = false;
            lstOrder.Items.Clear();
            totalCost = 0;
            lblTotalCost.Text = "총 금액: " + totalCost.ToString("N0") + "원";
            // Ensure no prior menu-warning message is visible
            label3.Text = "";
            // Remove initial focus so a radio button doesn't appear selected
            this.ActiveControl = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        int totalCost = 0;
        // Control groups for keyboard navigation
        private Control[] menuRadios;
        private Control[] optionChecks;
        private Control[] actionButtons;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle Tab to move between logical groups
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                bool forward = !e.Shift;
                MoveToNextGroup(forward);
                return;
            }

            // Handle arrow keys for navigating items
            if (IsControlInGroup(this.ActiveControl, menuRadios))
            {
                int idx = IndexOfControl(this.ActiveControl, menuRadios);
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                {
                    int next = (idx + 1) % menuRadios.Length;
                    menuRadios[next].Focus();
                    ((RadioButton)menuRadios[next]).Checked = true;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                {
                    int prev = (idx - 1 + menuRadios.Length) % menuRadios.Length;
                    menuRadios[prev].Focus();
                    ((RadioButton)menuRadios[prev]).Checked = true;
                    e.Handled = true;
                }
                return;
            }

            if (IsControlInGroup(this.ActiveControl, optionChecks))
            {
                int idx = IndexOfControl(this.ActiveControl, optionChecks);
                if (e.KeyCode == Keys.Down)
                {
                    int next = (idx + 1) % optionChecks.Length;
                    optionChecks[next].Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int prev = (idx - 1 + optionChecks.Length) % optionChecks.Length;
                    optionChecks[prev].Focus();
                    e.Handled = true;
                }
                return;
            }

            // Space toggles current checkbox or selects a radio when focused
            if (e.KeyCode == Keys.Space)
            {
                if (this.ActiveControl is CheckBox cb)
                {
                    cb.Checked = !cb.Checked;
                    e.Handled = true;
                    return;
                }

                if (this.ActiveControl is RadioButton rb)
                {
                    rb.Checked = true;
                    e.Handled = true;
                    return;
                }
            }

            // Enter activates a focused button (if any). Otherwise AcceptButton handles it.
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ActiveControl is Button b)
                {
                    b.PerformClick();
                    e.Handled = true;
                    return;
                }
            }
        }

        private bool IsControlInGroup(Control c, Control[] group)
        {
            if (c == null) return false;
            foreach (var ctrl in group)
            {
                if (ctrl == c) return true;
            }
            return false;
        }

        private int IndexOfControl(Control c, Control[] group)
        {
            for (int i = 0; i < group.Length; i++) if (group[i] == c) return i;
            return 0;
        }

        private void MoveToNextGroup(bool forward)
        {
            var groups = new List<Control[]>() { menuRadios, optionChecks, new Control[] { lstOrder }, actionButtons };
            Control focused = this.ActiveControl;
            int current = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                if (IsControlInGroup(focused, groups[i]))
                {
                    current = i;
                    break;
                }
            }

            int next = (current + (forward ? 1 : -1) + groups.Count) % groups.Count;
            // Focus the first control of the next group
            var target = groups[next][0];
            target.Focus();
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // If no menu radio is selected, show message in label3 and exit
            if (!rdoHamBurger.Checked && !rdoBulgogiBurger.Checked && !rdoChickenBurger.Checked)
            {
                label3.Text = "메뉴를 선택하세요.";
                return;
            }

            // Clear any previous message
            label3.Text = "";

            if (rdoHamBurger.Checked)
            {
                totalCost += 5000;
                lstOrder.Items.Add("햄버거 5,000원");
            }

            if (rdoBulgogiBurger.Checked)
            {
                totalCost += 4000;
                lstOrder.Items.Add("불고기 버거 4,000");
            }

            if (rdoChickenBurger.Checked)
            {
                totalCost += 3000;
                lstOrder.Items.Add("치킨버거 3,000");
            }

            if (chkPotato.Checked)
            {
                totalCost += 3500;
                lstOrder.Items.Add("감자튀김 3,500원");
            }

            if (chkCola.Checked)
            {
                totalCost += 2500;
                lstOrder.Items.Add("콜라 2,500원");
            }

            if (chkCheese.Checked)
            {
                totalCost += 1500;
                lstOrder.Items.Add("치즈 추가 1,500원");
            }

            if (chkSauce.Checked)
            {
                totalCost += 500;
                lstOrder.Items.Add("소스 추가 500원");
            }

            lblTotalCost.Text = "총 금액: " + totalCost.ToString("N0") + "원";
            // Order processed successfully; ensure any previous message is cleared
            // (message cleared above when a menu was selected)
        }

        private void btninit_Click(object sender, EventArgs e)
        {
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            chkPotato.Checked = false;
            chkCola.Checked = false;
            chkCheese.Checked = false;
            chkSauce.Checked = false;
            lstOrder.Items.Clear();
            totalCost = 0;
            lblTotalCost.Text = "총 금액: " + totalCost.ToString("N0") + "원";
            // Clear any menu-warning message when initializing
            label3.Text = "";

        }

        private void lblTotalCost_Click(object sender, EventArgs e)
        {

        }

        private void rdoHamBurger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoBulgogiBurger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Ensure radios are unchecked after the form is shown (overrides any designer/runtime selection)
            rdoHamBurger.Checked = false;
            rdoBulgogiBurger.Checked = false;
            rdoChickenBurger.Checked = false;
            // Remove focus so none appears selected
            this.ActiveControl = null;
        }
    }
}
