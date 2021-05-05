
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System;


namespace ProjectNavigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ApplicationContext db;
        //DbContextOptions<ApplicationContext> DbSQLiteOpt;

        public MainWindow()
        {
            InitializeComponent();

            //using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            //{
            //    db.Devs.Load();
            //    this.DataContext = db.Devs.Local.ToBindingList();
            //    //this.DataContext = db.Devs;
            //}

            UpdateList();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DevWindow DevWindow = new DevWindow(new Dev());
            if (DevWindow.ShowDialog() == true)
            {
                //Dev Dev = DevWindow.Dev;
                //if (!String.IsNullOrEmpty(DevWindow.Dev.Developer.ToString()))
                if (!String.IsNullOrEmpty(DevWindow.Dev.Developer))
                {
                    Dev Dev = DevWindow.Dev;
                    //using (ApplicationContext db = new ApplicationContext(DbSQLiteOpt))
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                    {
                        db.Devs.Add(Dev);
                        db.SaveChanges();
                        UpdateList();
                    }
                }
                else
                {
                    NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                    if (NotifyWindow.ShowDialog() == true)
                    {
                        this.Add_Click(sender, e);
                    }
                }
            }
        }

        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (DevsList.SelectedItem == null) return;
            // получаем выделенный объект
            Dev Dev = DevsList.SelectedItem as Dev;

            DevWindow DevWindow = new DevWindow(new Dev
            {
                ID = Dev.ID,
                Developer = Dev.Developer,
                FullCompanyName = Dev.FullCompanyName,
                Contacts = Dev.Contacts,
                DesignStatus = Dev.DesignStatus,
                Note = Dev.Note
            });

            if (DevWindow.ShowDialog() == true)
            {
                //using (ApplicationContext db = new ApplicationContext(DbSQLiteOpt))
                using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                {
                    // получаем измененный объект
                    Dev = db.Devs.Find(DevWindow.Dev.ID);
                    if (Dev != null)
                    {
                        Dev.Developer = DevWindow.Dev.Developer;
                        Dev.FullCompanyName = DevWindow.Dev.FullCompanyName;
                        Dev.Contacts = DevWindow.Dev.Contacts;
                        Dev.DesignStatus = DevWindow.Dev.DesignStatus;
                        Dev.Note = DevWindow.Dev.Note;
                        db.Entry(Dev).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                UpdateList();
            }
        }
        
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (DevsList.SelectedItem == null) return;
            // получаем выделенный объект
            Dev Dev = DevsList.SelectedItem as Dev;
            //using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {

                db.Devs.Remove(Dev);
                db.SaveChanges();
            }
            UpdateList();
        }

        // обновление списка
        private void UpdateList()
        {
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {
                db.Devs.Load();
                this.DataContext = db.Devs.Local.ToBindingList();
            }
        }
    }
}
