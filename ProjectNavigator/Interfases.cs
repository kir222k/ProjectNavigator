using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNavigator
{
    /// <summary>
    /// Документ.
    /// </summary>
    interface IDoc
    {
        /// <summary>
        /// ID документа.
        /// </summary>
        // string DocID { get; set; }
        int ID { get; set; }

        /// <summary>
        /// Блок.
        /// </summary>
        string Block { get; set; }

        /// <summary>
        /// Этаж.
        /// </summary>
        string Level { get; set; }

        /// <summary>
        /// Комплект.
        /// </summary>
        string Pack { get; set; }

        /// <summary>
        /// Разработчик.
        /// </summary>
        string Dev { get; set; }

        string CodePack { get; set; }
        string NumDoc { get; set; }
        string CodeDoc { get; set; }
        string NameDoc { get; set; }

        //string CustomCategory1 { get; set; }
        //string CustomCategory2 { get; set; }
        //string CustomCategory3 { get; set; }
        //string CustomCategory4 { get; set; }
        //string CustomCategory5 { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        string Note { get; set; }

    }

    /// <summary>
    /// Ревизия.
    /// </summary>
    interface IRevisionDoc
    {
        /// <summary>
        /// Номер  ревизии.
        /// </summary>
       // string NumberRev { get; set; }

        string CodeDoc { get; set; }

        /// <summary>
        /// Дата передачи ревизии.
        /// </summary>
        DateTime DateRev { get; set; }

        /// <summary>
        /// Путь к файлу. PDF.
        /// </summary>
        string FilePathPdf { get; set; }

        /// <summary>
        /// Путь к файлу. NATIVE.
        /// </summary>
        string FilePathNative { get; set; }

    }

    /// <summary>
    /// Официальная ревизия.
    /// </summary>
    interface IOfficialRevisionDoc : IRevisionDoc
    {
        /// <summary>
        /// ID официальной ревизии.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Статус по Aconnex.
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// Процесс по Aconnex.
        /// </summary>
        int Process { get; set; }

    }

    /// <summary>
    /// Нефициальная ревизия.
    /// </summary>
    interface IUnOfficialRevisionDoc : IRevisionDoc
    {
        /// <summary>
        /// ID неофициальной ревизии.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Если TRUE, то выдана как офф.
        /// </summary>
        bool IsOfficialRev { get; set; }

        /// <summary>
        /// Соттветствуюший номер офф. ревизии.
        /// </summary>
        string OfficialNumberRev { get; set; }


    }

    /// <summary>
    /// Разработчик/исполнитель.
    /// </summary>
    interface IDev
    {
        /// <summary>
        /// ID записи.
        /// </summary>
        int ID { get; set; }
        /// <summary>
        /// Разраб.
        /// </summary>
        string Developer { get; set; }
        /// <summary>
        /// Компания.
        /// </summary>
        string FullCompanyName { get; set; }
        /// <summary>
        /// Контакт.
        /// </summary>
        string Contacts { get; set; }
        /// <summary>
        /// Статус в проекте.
        /// </summary>
        string DesignStatus { get; set; }
        /// <summary>
        /// Примеч.
        /// </summary>
        string Note { get; set; }

    }

    interface IBlock
    {
        int ID { get; set; }
        string BlockName { get; set; }
        string Note { get; set; }
    }

    interface ILevel
    {
        int ID { get; set; }
        string LevelName { get; set; }
        string Note { get; set; }
    }

    interface IPack
    {
        int ID { get; set; }
        string PackName { get; set; }
        string Note { get; set; }
    }

}
