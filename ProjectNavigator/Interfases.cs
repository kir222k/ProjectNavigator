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
        string DocID { get; set; }

        /// <summary>
        /// Разработчик.
        /// </summary>
        string Creator { get; set; }

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
        string Set { get; set; }

        string CustomCategory1 { get; set; }
        string CustomCategory2 { get; set; }
        string CustomCategory3 { get; set; }
        string CustomCategory4 { get; set; }
        string CustomCategory5 { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Путь к файлу. напр. PDF.
        /// </summary>
        string FilePath { get; set; }
    }

    /// <summary>
    /// Ревизия.
    /// </summary>
    interface IRevisionDoc
    {
        /// <summary>
        /// Номер  ревизии.
        /// </summary>
        string NumberRev { get; set; }

        /// <summary>
        /// Дата передачи ревизии.
        /// </summary>
        DateTime DateRev { get; set; }
    }

    /// <summary>
    /// Официальная ревизия.
    /// </summary>
    interface IOfficialRevisionDoc : IDoc, IRevisionDoc
    {
        /// <summary>
        /// ID официальной ревизии.
        /// </summary>
        string OfficialRevID { get; set; }

        /// <summary>
        /// Процесс по Aconnex.
        /// </summary>
        int Process { get; set; }

        /// <summary>
        /// Статус по Aconnex.
        /// </summary>
        string Status { get; set; }

    }

    /// <summary>
    /// Нефициальная ревизия.
    /// </summary>
    interface IUnOfficialRevisionDoc : IDoc, IRevisionDoc
    {
        /// <summary>
        /// ID неофициальной ревизии.
        /// </summary>
        string UnOfficialRevID { get; set; }

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
}
