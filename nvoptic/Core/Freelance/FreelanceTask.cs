using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvopticParser.Core.Freelance
{
    class FreelanceTask
    {
        private int id;
        private string title;
        private string price;
        private string link;
        private string description;
        private string deadline;
        private string prepayment;
        private string payment;
        private string publishDate;
        private string employer;
        private string employerReg;
        private int employerNumProject;

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
        }
        public string Price
        {
            get
            {
                return price;
            }
        }
        public string Link
        {
            get
            {
                return link;
            }
        }
        public string Description
        {
            get
            {
                if (description != null || description != "")
                {
                    return description;
                }
                else
                {
                    return "Доступно только для Pro";
                }
            }
            set
            {
                description = value;
            }
        }
        public string Deadline
        {
            get
            {
                if (deadline == null || deadline == "")
                {
                    return "Дедлайн не установлен";
                }
                else
                {
                    return deadline;
                }
            }
            set
            {
                deadline = value;
            }
        }
        public string Prepayment
        {
            get
            {
                if (prepayment == null || prepayment == "")
                {
                    return "Предоплата не оговорена";
                }
                else
                {
                    return prepayment;
                }
            }
            set
            {
                prepayment = value;
            }
        }
        public string Payment
        {
            get
            {
                if (payment == null || payment == "")
                {
                    return "Способ оплаты не определен";
                }
                else
                {
                    return payment;
                }
            }
            set
            {
                payment = value;
            }
        }
        public string PublishDate
        {
            get
            {
                if (publishDate == null || publishDate == "")
                {
                    return "Дата публикации не определена";
                }
                else
                {
                    return publishDate;
                }
            }
            set
            {
                publishDate = value;
            }
        }
        public string Employer
        {
            get
            {
                if (employer == null || employer == "")
                {
                    return "Заказчик не определен";
                }
                else
                {
                    return employer;
                }
            }
            set
            {
                employer = value;
            }
        }
        public string EmployerReg
        {
            get
            {
                if (employerReg == null || employerReg == "")
                {
                    return "Дата регистрации заказчика не определена";
                }
                else
                {
                    return employerReg;
                }
            }
            set
            {
                employerReg = value;
            }
        }
        public int EmployerNumProject
        {
            get
            {
                return employerNumProject;
            }
            set
            {
                employerNumProject = value;
            }
        }
        #endregion

        public FreelanceTask(int id, string title, string price, string link)
        {
            this.id = id;
            this.title = title;
            this.price = price;
            this.link = link;
        }
    }
}
