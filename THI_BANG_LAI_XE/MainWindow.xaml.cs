using System.Text;
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


namespace THI_BANG_LAI_XE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Query context;
        private readonly ThiBangLaiXeContext dbSet;
        public MainWindow()
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