using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderWindowForm
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        Form_Create FormCreate;
        Form_Update FormUpdate;

        private Graphics graphics;
        private Task task;
        OrderApp.OrderService orderService = new OrderApp.OrderService();
        DataTable dt = new DataTable();
        

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("ID", typeof(System.String));
            
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormCreate = new Form_Create();
            FormCreate.MyEvent += new MyDelegate(Create_Event);
            FormCreate.Show();
            return;
        }
        private void Create_Event(string t1, string t2, string t3, string t4)
        {
            int t;
            bool result;
            result = int.TryParse(t4, out t);
            OrderApp.Customer customer = new OrderApp.Customer();
            OrderApp.Order order = new OrderApp.Order(t, customer);
            orderService.AddOrder(order);
            return;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormCreate = new Form_Create();
            FormCreate.MyEvent += new MyDelegate(form1_2_Event);
            FormCreate.Show();
            return;
        }
        private void form1_2_Event(string t1, string t2, string t3, string t4)
        {
            /*int t;
            bool result;
            result = int.TryParse(t4, out t);
            OrderApp.Customer customer = new OrderApp.Customer();
            OrderApp.Order order = new OrderApp.Order(t, customer);
            orderService.AddOrder(order);
            return;*/
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            FormCreate = new Form_Create();
            FormCreate.MyEvent += new MyDelegate(form1_3_Event);
            FormCreate.Show();
            return;
        }
        private void form1_3_Event(string t1, string t2, string t3, string t4)
        {
            /*int t;
            bool result;
            result = int.TryParse(t4, out t);
            OrderApp.Customer customer = new OrderApp.Customer();
            OrderApp.Order order = new OrderApp.Order(t, customer);
            orderService.AddOrder(order);
            return;*/
        }

    }
}
