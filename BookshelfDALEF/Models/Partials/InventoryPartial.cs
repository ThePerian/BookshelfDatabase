using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BookshelfDALEF.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string AuthorBookName => $"{Author} + \"{BookName}\"";

        public override string ToString()
        {
            string readStatus = ReadStatus ? "прочитано" : "не прочитано";
            //Поскольку автор или название могут быть не указаны, предоставить стандартные
            return $"{BookId}: {Author??"Без автора"} " +
                $"\"{BookName??"Без названия"}\", {ReadStatus}";
        }

        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(BookId):
                        errors = GetErrorsFromAnnotaions(nameof(BookId), BookId);
                        break;
                    case nameof(Author):
                        hasError = CheckAuthorAndBookName();
                        if (Author.ToLower().Contains("роулинг"))
                        {
                            AddError(nameof(Author), "Указан недопустимый автор");
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Author));
                        errors = GetErrorsFromAnnotaions(nameof(Author), Author);
                        break;
                    case nameof(BookName):
                        hasError = CheckAuthorAndBookName();
                        if (!hasError) ClearErrors(nameof(BookName));
                        errors = GetErrorsFromAnnotaions(nameof(BookName), BookName);
                        break;
                    case nameof(ReadStatus):
                        errors = GetErrorsFromAnnotaions(nameof(ReadStatus), ReadStatus);
                        break;
                }
                if (errors != null && errors.Length > 0)
                {
                    AddErrors(columnName, errors.ToList());
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }

        internal bool CheckAuthorAndBookName()
        {
            //В целях тестирования запретим сочетание определенного автора и книги
            if (Author.ToLower().Contains("толкин")
                && BookName.ToLower().Contains("гарри поттер"))
            {
                AddError(nameof(Author), "Этот автор не писал таких книг");
                AddError(nameof(BookName), "Этот автор не писал таких книг");
                return true;
            }
            return false;
        }
    }
}
