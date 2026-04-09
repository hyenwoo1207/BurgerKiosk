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
            // Remove initial focus so a radio button doesn't appear selected
            this.ActiveControl = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        int totalCost = 0;
        private void btnOrder_Click(object sender, EventArgs e)
        {
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

            if (!rdoHamBurger.Checked && !rdoBulgogiBurger.Checked
                && !rdoChickenBurger.Checked)
            {
                MessageBox.Show("메뉴를 선택하세요.");

                return;

            }
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
