using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;


namespace THI_BANG_LAI_XE.View
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        private readonly Query context;
        private readonly ThiBangLaiXeContext dbSet;
        public MainWindow()
        public UserProfilePage()
        {
            InitializeComponent();
            this.dbSet = new ThiBangLaiXeContext();
            context = new Query(dbSet);
        }
        public void getListCourse()
        {
            var course = context.courseDao.GetCourseList();
        }
    }
}
