
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
            UpdateDevList();
            UpdateBlockList();
            UpdateLevelList();
            UpdatePackList();
        }

        // РАЗРАБ

        // добавление
        private void Add_Dev_Click(object sender, RoutedEventArgs e)
        {
            DevWindow DevWindow = new DevWindow(new Dev());
            if (DevWindow.ShowDialog() == true)
            {
                if (!String.IsNullOrEmpty(DevWindow.Dev.Developer))
                {
                    Dev Dev = DevWindow.Dev;
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                    {
                        db.Devs.Add(Dev);
                        db.SaveChanges();
                        UpdateDevList();
                    }
                }
                else
                {
                    NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                    if (NotifyWindow.ShowDialog() == true)
                    {
                        this.Add_Dev_Click(sender, e);
                    }
                }
            }
        }

        // редактирование
        private void Edit_Dev_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (DevsList.SelectedItem == null) return;
            // получаем выделенный объект
            Dev Dev = DevsList.SelectedItem as Dev;

            if (Dev != null)
            {
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
                    if (!String.IsNullOrEmpty(DevWindow.Dev.Developer))
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
                        UpdateDevList();
                    }
                    else
                    {
                        NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                        if (NotifyWindow.ShowDialog() == true)
                        {
                            this.Add_Dev_Click(sender, e);
                        }

                    }
                }
            }
        }
        
        // удаление
        private void Delete_Dev_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (DevsList.SelectedItem == null) return;
            // получаем выделенный объект
            Dev Dev = DevsList.SelectedItem as Dev;

            if (Dev != null)
            {
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                {

                    db.Devs.Remove(Dev);
                    db.SaveChanges();
                }
                UpdateDevList();
            }
        }

        // обновление списка
        private void UpdateDevList()
        {
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {
                db.Devs.Load();
                this.DevsList.DataContext = db.Devs.Local.ToBindingList();
            }
        }


        // БЛОКИ

        // добавление
        private void Add_Block_Click(object sender, RoutedEventArgs e)
        {
            BlockWindow BlockWindow = new BlockWindow(new Block());
            if (BlockWindow.ShowDialog() == true)
            {
                if (!String.IsNullOrEmpty(BlockWindow.Block.BlockName))
                {

                    //NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = $"sender= {sender.ToString()}" });
                    //NotifyWindow.ShowDialog();
                    //if (NotifyWindow.ShowDialog() == true)

                    Block Block = BlockWindow.Block;
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                    {
                        db.Blocks.Add(Block);
                        db.SaveChanges();
                        UpdateBlockList();
                    }
                }
                else
                {
                    NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                    if (NotifyWindow.ShowDialog() == true)
                    {
                        this.Add_Block_Click(sender, e);
                    }
                }
            }
        }

        // редактирование
        private void Edit_Block_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (BlocksList.SelectedItem == null) return;
            // получаем выделенный объект
            Block Block = BlocksList.SelectedItem as Block;

            if (Block != null)
            {
                BlockWindow BlockWindow = new BlockWindow(new Block
                {
                    ID = Block.ID,
                    BlockName = Block.BlockName,
                    //FullCompanyName = Block.FullCompanyName,
                    //Contacts = Block.Contacts,
                    //DesignStatus = Block.DesignStatus,
                    Note = Block.Note
                });

                if (BlockWindow.ShowDialog() == true)
                {
                    if (!String.IsNullOrEmpty(BlockWindow.Block.BlockName))
                    {

                        //using (ApplicationContext db = new ApplicationContext(DbSQLiteOpt))
                        using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                        {
                            // получаем измененный объект
                            Block = db.Blocks.Find(BlockWindow.Block.ID);
                            if (Block != null)
                            {
                                Block.BlockName = BlockWindow.Block.BlockName;
                                //Block.FullCompanyName = BlockWindow.Block.FullCompanyName;
                                //Block.Contacts = BlockWindow.Block.Contacts;
                                //Block.DesignStatus = BlockWindow.Block.DesignStatus;
                                Block.Note = BlockWindow.Block.Note;
                                db.Entry(Block).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        UpdateBlockList();
                    }
                    else
                    {
                        NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                        if (NotifyWindow.ShowDialog() == true)
                        {
                            this.Add_Block_Click(sender, e);
                        }

                    }
                }
            }
        }

        // удаление
        private void Delete_Block_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (BlocksList.SelectedItem == null) return;
            // получаем выделенный объект
            Block Block = BlocksList.SelectedItem as Block;

            if (Block != null)
            {
                using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                {

                    db.Blocks.Remove(Block);
                    db.SaveChanges();
                }
                UpdateBlockList();
            }
        }

        // обновление списка
        private void UpdateBlockList()
        {
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {
                db.Blocks.Load();
                this.BlocksList.DataContext = db.Blocks.Local.ToBindingList();
            }
        }


        // УРОВНИ
        private void Add_Level_Click(object sender, RoutedEventArgs e)
        {
            LevelWindow LevelWindow = new LevelWindow(new Level());
            if (LevelWindow.ShowDialog() == true)
            {
                if (!String.IsNullOrEmpty(LevelWindow.Level.LevelName))
                {

                    //NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = $"sender= {sender.ToString()}" });
                    //NotifyWindow.ShowDialog();
                    //if (NotifyWindow.ShowDialog() == true)

                    Level Level = LevelWindow.Level;
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                    {
                        db.Levels.Add(Level);
                        db.SaveChanges();
                        UpdateLevelList();
                    }
                }
                else
                {
                    NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                    if (NotifyWindow.ShowDialog() == true)
                    {
                        this.Add_Level_Click(sender, e);
                    }
                }
            }
        }

        // редактирование
        private void Edit_Level_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (LevelsList.SelectedItem == null) return;
            // получаем выделенный объект
            Level Level = LevelsList.SelectedItem as Level;

            if (Level != null)
            {
                LevelWindow LevelWindow = new LevelWindow(new Level
                {
                    ID = Level.ID,
                    LevelName = Level.LevelName,
                    //FullCompanyName = Level.FullCompanyName,
                    //Contacts = Level.Contacts,
                    //DesignStatus = Level.DesignStatus,
                    Note = Level.Note
                });

                if (LevelWindow.ShowDialog() == true)
                {
                    if (!String.IsNullOrEmpty(LevelWindow.Level.LevelName))
                    {

                        //using (ApplicationContext db = new ApplicationContext(DbSQLiteOpt))
                        using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                        {
                            // получаем измененный объект
                            Level = db.Levels.Find(LevelWindow.Level.ID);
                            if (Level != null)
                            {
                                Level.LevelName = LevelWindow.Level.LevelName;
                                //Level.FullCompanyName = LevelWindow.Level.FullCompanyName;
                                //Level.Contacts = LevelWindow.Level.Contacts;
                                //Level.DesignStatus = LevelWindow.Level.DesignStatus;
                                Level.Note = LevelWindow.Level.Note;
                                db.Entry(Level).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        UpdateLevelList();
                    }
                    else
                    {
                        NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                        if (NotifyWindow.ShowDialog() == true)
                        {
                            this.Add_Level_Click(sender, e);
                        }

                    }
                }
            }
        }

        // удаление
        private void Delete_Level_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (LevelsList.SelectedItem == null) return;
            // получаем выделенный объект
            Level Level = LevelsList.SelectedItem as Level;

            if (Level != null)
            {
                using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                {

                    db.Levels.Remove(Level);
                    db.SaveChanges();
                }
                UpdateLevelList();
            }
        }

        // обновление списка
        private void UpdateLevelList()
        {
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {
                db.Levels.Load();
                this.LevelsList.DataContext = db.Levels.Local.ToBindingList();
            }
        }

        // КОМПЛЕКТЫ
        private void Add_Pack_Click(object sender, RoutedEventArgs e)
        {
            
           this.TabPack.Header+= this.TabPack.DataContext.ToString();

            PackWindow PackWindow = new PackWindow(new Pack());
            if (PackWindow.ShowDialog() == true)
            {
                if (!String.IsNullOrEmpty(PackWindow.Pack.PackName))
                {

                    //NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = $"sender= {sender.ToString()}" });
                    //NotifyWindow.ShowDialog();
                    //if (NotifyWindow.ShowDialog() == true)

                    Pack Pack = PackWindow.Pack;
                    using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                    {
                        db.Packs.Add(Pack);
                        db.SaveChanges();
                        UpdatePackList();
                    }
                }
                else
                {
                    NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                    if (NotifyWindow.ShowDialog() == true)
                    {
                        this.Add_Pack_Click(sender, e);
                    }
                }
            }
        }

        // редактирование
        private void Edit_Pack_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (PacksList.SelectedItem == null) return;
            // получаем выделенный объект
            Pack Pack = PacksList.SelectedItem as Pack;

            if (Pack != null)
            {
                PackWindow PackWindow = new PackWindow(new Pack
                {
                    ID = Pack.ID,
                    PackName = Pack.PackName,
                    //FullCompanyName = Pack.FullCompanyName,
                    //Contacts = Pack.Contacts,
                    //DesignStatus = Pack.DesignStatus,
                    Note = Pack.Note
                });

                if (PackWindow.ShowDialog() == true)
                {
                    if (!String.IsNullOrEmpty(PackWindow.Pack.PackName))
                    {

                        //using (ApplicationContext db = new ApplicationContext(DbSQLiteOpt))
                        using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                        {
                            // получаем измененный объект
                            Pack = db.Packs.Find(PackWindow.Pack.ID);
                            if (Pack != null)
                            {
                                Pack.PackName = PackWindow.Pack.PackName;
                                //Pack.FullCompanyName = PackWindow.Pack.FullCompanyName;
                                //Pack.Contacts = PackWindow.Pack.Contacts;
                                //Pack.DesignStatus = PackWindow.Pack.DesignStatus;
                                Pack.Note = PackWindow.Pack.Note;
                                db.Entry(Pack).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        UpdatePackList();
                    }
                    else
                    {
                        NotifyWindow NotifyWindow = new NotifyWindow(new Notify { NotifyText = "Необходимо указать Разработчика!" });
                        if (NotifyWindow.ShowDialog() == true)
                        {
                            this.Add_Pack_Click(sender, e);
                        }

                    }
                }
            }
        }

        // удаление
        private void Delete_Pack_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (PacksList.SelectedItem == null) return;
            // получаем выделенный объект
            Pack Pack = PacksList.SelectedItem as Pack;

            if (Pack != null)
            {
                using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
                {

                    db.Packs.Remove(Pack);
                    db.SaveChanges();
                }
                UpdatePackList();
            }
        }

        // обновление списка
        private void UpdatePackList()
        {
            using (ApplicationContext db = new ApplicationContext(DbSQLiteBuilder.GetSQLiteConnectOptions()))
            {
                db.Packs.Load();
                this.TabPack.DataContext = db.Packs.Local.ToBindingList();
                //this.PacksList.DataContext = db.Packs.Local.ToBindingList();
            }
        }



    }
}
