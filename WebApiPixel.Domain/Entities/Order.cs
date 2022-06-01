using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : EntityBase
    {
        /// <summary>
        /// Фио клиента
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Статус принятия заказа (true, false)
        /// </summary>
        public bool IsAccepted { get; set; }

/*        /// <summary>
        /// Id формата бумаги
        /// </summary>
        public Guid IdSize { get; set; }

        /// <summary>
        /// Id материала бумаги
        /// </summary>
        public Guid IdMaterial { get; set; }

        /// <summary>
        /// Id плотности бумаги
        /// </summary>
        public Guid IdDensity { get; set; }

        /// <summary>
        /// Id цветности бумаги (1 + 0...)
        /// </summary>
        public Guid IdColor { get; set; }

        /// <summary>
        /// Количество копий
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Дата, когда нужно выполнить заказ
        /// </summary>
        public string Deadline { get; set; }

        /// <summary>
        /// Выбранные цвета
        /// </summary>
        public string SelectedColors { get; set; }*/

        /// <summary>
        /// Подробности заказа
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Исходники, отправленные клиентом
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// id товара
        /// </summary>
        public Guid WareId { get; set; }
        
        /// <summary>
        /// Товар
        /// </summary>
        public virtual Ware Ware { get; set; }

        /// <summary>
        /// Хронология заказа
        /// </summary>
        public virtual OrderHronology OrderHronology { get; set; }

        /// <summary>
        /// СотрудникЗаказ
        /// </summary>
        public virtual EmployeeOrder EmployeeOrder { get; set; }
    }
}
