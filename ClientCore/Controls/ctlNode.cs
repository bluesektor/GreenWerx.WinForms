using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenWerx.Models;
using GreenWerx.Managers.Membership;
using GreenWerx.Utilites.Extensions;
using GreenWerx.Models.Store;
using GreenWerx.Models.Membership;

namespace ClientCore.Controls
{
    public partial class ctlNode : UserControl
    {
        private  AccountManager _accountManager;

        private UserManager _userManager;

        private INode _node;

        private string _connectionKey;

        private string _sessionKey;

        public ctlNode(string dbConnectionKey, string sessionKey)
        {
            InitializeComponent();

            _connectionKey = dbConnectionKey;
            _sessionKey = sessionKey;

            _accountManager = new AccountManager(dbConnectionKey, sessionKey);
            _userManager = new UserManager(dbConnectionKey, sessionKey);

        }

        public void Show(INode n)
        {
            _node = null;

            if (n == null)
                return;

            _node = n;
          
            txtName.Text = _node.Name;
            txtStatus.Text = _node.Status;
            txtSortOrder.Text = _node.SortOrder.ToString();
            txtRoleWeight.Text = _node.RoleWeight.ToString();

            chkActive.Checked = _node.Active;
            chkDeleted.Checked = _node.Deleted;
            chkPrivate.Checked = _node.Private;

            lblCreatedBy.Text =  (_userManager.Get(_node.CreatedBy).Result as User) ?.Name;
            lblDateCreated.Text = _node.DateCreated.ToShortDateString();

            for(int i = 0; i < cboRoleOperation.Items.Count; i++)
            {
                string cboItem = cboRoleOperation.Items[i].ToString();
                if (string.IsNullOrEmpty(cboItem))
                   continue;

                if (cboItem.EqualsIgnoreCase(_node.RoleOperation,true))
                {
                    cboRoleOperation.SelectedIndex = i;
                    break;
                }
            }
           var res=  _accountManager.Get(_node.AccountUUID);
            if(res.Code  == 200)
                lblAccount.Text =(res.Result as Account)?.Name;
        
            ////if (File.Exists(_node.Image))
            ////{
            ////    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ////    picBox.Image = Image.FromFile(_node.Image);
            ////}
        }

        public INode Get()
        {
            if (_node == null)
            {
                _node = new Node();
            }

            _node.Name = txtName.Text;
            _node.Status = txtStatus.Text;

            _node.SortOrder = StringEx.ConvertTo<int>(txtSortOrder.Text);
            _node.RoleWeight = StringEx.ConvertTo<int>(txtRoleWeight.Text);

            _node.Active = chkActive.Checked;
            _node.Deleted =chkDeleted.Checked;
            _node.Private =chkPrivate.Checked;

            _node.RoleOperation = cboRoleOperation.Text;
            return _node;
        }

       
    }
}
