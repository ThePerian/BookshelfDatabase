using System;
using BookshelfDALEF.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BookshelfDALEF.Repos
{
    public abstract class BaseRepo<T>: IDisposable where T:class, new()
    {
        public BookshelfEntities Context { get; } = new BookshelfEntities();

        protected DbSet<T> Table;

        //Сохранение изменений
        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                //Генерируется, когда возникла ошибка параллелизма
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch(DbUpdateException ex)
            {
                //Генерируется, когда обновление базы данных терпит отказ
                //Проверить внутреннее исключение, чтобы получить дополнительные
                //сведения и затронутые объекты;
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch(CommitFailedException ex)
            {
                //Обработать здесь ошибки, связанные с транзакцией
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch(Exception ex)
            {
                //Были сгенерированы какие-то другие исключения,
                //которые должны быть обработаны
                throw;
            }
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Генерируется, когда возникла ошибка параллелизма
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Генерируется, когда обновление базы данных терпит отказ
                //Проверить внутреннее исключение, чтобы получить дополнительные
                //сведения и затронутые объекты;
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch (CommitFailedException ex)
            {
                //Обработать здесь ошибки, связанные с транзакцией
                //пока что просто сгенерировать исключение повторно
                throw;
            }
            catch (Exception ex)
            {
                //Были сгенерированы какие-то другие исключения,
                //которые должны быть обработаны
                throw;
            }
        }

        //Извлечение записей
        public T GetOne(int? id) => Table.Find(id);
        public Task<T> GetOneAsync(int? id) => Table.FindAsync(id);
        public List<T> GetAll() => Table.ToList();
        public Task<List<T>> GetAllAsync() => Table.ToListAsync();
        
        //Извлечение записей с помощью SQL
        //пока что пренебрегаем безопасным использование и просто
        //передаем строку запроса
        public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql) 
            => Table.SqlQuery(sql).ToListAsync();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql, sqlParametersObjects).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql).ToListAsync();

        //Добавление записей
        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        //Обновление записей
        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        //Удаление записей
        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        //Реализация IDisposable
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Context.Dispose();
                //Освободить здесь любые управляемые объекты
            }

            disposed = true;
        }
    }
}
