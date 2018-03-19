﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Configuration file:     "RX.WXMember.Models\App.config"
//     Connection String Name: "MyDbContext"
//     Connection String:      "Data Source=.;Initial Catalog=wx_member;Uid=sa;Pwd=Barcode2017;MultipleActiveResultSets=True;Application Name=RocApp"
// ------------------------------------------------------------------------------------------------
// Database Edition       : Express Edition (64-bit)
// Database Engine Edition: Express

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RX.WXMember.Models
{
    using System.Linq;

    #region Unit of work

    public interface IMyDbContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Customer> Customers { get; set; } // Customer
        System.Data.Entity.DbSet<RegRecord> RegRecords { get; set; } // RegRecord
        System.Data.Entity.DbSet<ShiftRecord> ShiftRecords { get; set; } // ShiftRecord

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        // Stored Procedures
        int GetMaxId(string groundCode);
        // GetMaxIdAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class MyDbContext : System.Data.Entity.DbContext, IMyDbContext
    {
        public System.Data.Entity.DbSet<Customer> Customers { get; set; } // Customer
        public System.Data.Entity.DbSet<RegRecord> RegRecords { get; set; } // RegRecord
        public System.Data.Entity.DbSet<ShiftRecord> ShiftRecords { get; set; } // ShiftRecord

        static MyDbContext()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=MyDbContext")
        {
            InitializePartial();
        }

        public MyDbContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public MyDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public MyDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new RegRecordConfiguration());
            modelBuilder.Configurations.Add(new ShiftRecordConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration(schema));
            modelBuilder.Configurations.Add(new RegRecordConfiguration(schema));
            modelBuilder.Configurations.Add(new ShiftRecordConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);

        // Stored Procedures
        public int GetMaxId(string groundCode)
        {
            var groundCodeParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@groundCode", SqlDbType = System.Data.SqlDbType.NVarChar, Direction = System.Data.ParameterDirection.Input, Value = groundCode, Size = 20 };
            if (groundCodeParam.Value == null)
                groundCodeParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC @procResult = [dbo].[GetMaxId] @groundCode", groundCodeParam, procResultParam);

            return (int) procResultParam.Value;
        }

    }
    #endregion

    #region Fake Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class FakeMyDbContext : IMyDbContext
    {
        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<RegRecord> RegRecords { get; set; }
        public System.Data.Entity.DbSet<ShiftRecord> ShiftRecords { get; set; }

        public FakeMyDbContext()
        {
            Customers = new FakeDbSet<Customer>("Id");
            RegRecords = new FakeDbSet<RegRecord>("Id");
            ShiftRecords = new FakeDbSet<ShiftRecord>("Id");

            InitializePartial();
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        partial void InitializePartial();

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public System.Data.Entity.Infrastructure.DbChangeTracker _changeTracker;
        public System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get { return _changeTracker; } }
        public System.Data.Entity.Infrastructure.DbContextConfiguration _configuration;
        public System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get { return _configuration; } }
        public System.Data.Entity.Database _database;
        public System.Data.Entity.Database Database { get { return _database; } }
        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors()
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }


        // Stored Procedures
        public int GetMaxId(string groundCode)
        {

            return 0;
        }

    }

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class FakeDbSet<TEntity> : System.Data.Entity.DbSet<TEntity>, IQueryable, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly System.Reflection.PropertyInfo[] _primaryKeys;
        private readonly System.Collections.ObjectModel.ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();

            InitializePartial();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();

            InitializePartial();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new System.ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new System.ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override System.Collections.Generic.IEnumerable<TEntity> AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override System.Collections.Generic.IEnumerable<TEntity> RemoveRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Remove(entity);
            }
            return items;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return System.Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return System.Activator.CreateInstance<TDerivedEntity>();
        }

        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        System.Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<TEntity> System.Collections.Generic.IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator<TEntity> System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }

        partial void InitializePartial();
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncQueryProvider<TEntity> : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public System.Threading.Tasks.Task<object> ExecuteAsync(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute(expression));
        }

        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression)
        { }

        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class FakeDbAsyncEnumerator<T> : System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T>
    {
        private readonly System.Collections.Generic.IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(System.Collections.Generic.IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public System.Threading.Tasks.Task<bool> MoveNextAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Data.Entity.Infrastructure.IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // Customer
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class Customer
    {
        public int Id { get; set; } // Id (Primary key)
        public string Code { get; set; } // Code (length: 100)
        public string NickName { get; set; } // NickName (length: 100)
        public int Sex { get; set; } // Sex
        public string City { get; set; } // City (length: 100)
        public string Country { get; set; } // Country (length: 100)
        public string Province { get; set; } // Province (length: 100)
        public string Openid { get; set; } // Openid (length: 100)
        public string Unionid { get; set; } // Unionid (length: 100)
        public string HeadImgUrl { get; set; } // HeadImgUrl (length: 1000)
        public int Score { get; set; } // Score
        public System.DateTime CreateTime { get; set; } // CreateTime
        public System.DateTime LastTime { get; set; } // LastTime
        public bool IsStop { get; set; } // IsStop
        public bool IsManager { get; set; } // IsManager
        public string Password { get; set; } // Password (length: 100)
        public string Phone { get; set; } // Phone (length: 20)

        public Customer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // RegRecord
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class RegRecord
    {
        public int Id { get; set; } // Id (Primary key)
        public string Record { get; set; } // Record (length: 200)
        public string GroundCode { get; set; } // GroundCode (length: 100)
        public string RegCode { get; set; } // RegCode (length: 200)
        public System.DateTime CreateTime { get; set; } // CreateTime
        public string CreateUser { get; set; } // CreateUser (length: 100)

        public RegRecord()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ShiftRecord
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class ShiftRecord
    {
        public int Id { get; set; } // Id (Primary key)

        ///<summary>
        /// 场地编号
        ///</summary>
        [Display(Name="场地编号")]
        public string GroundCode { get; set; } // GroundCode (length: 20)

        ///<summary>
        /// 接班时间
        ///</summary>
        [Display(Name="接班时间")]
        public System.DateTime? CheckIn { get; set; } // CheckIn

        ///<summary>
        /// 交班时间
        ///</summary>
        [Display(Name="交班时间")]
        public System.DateTime? CheckOut { get; set; } // CheckOut

        ///<summary>
        /// 充值币数
        ///</summary>
        [Display(Name="充值币数")]
        public int SaleQty { get; set; } // SaleQty

        ///<summary>
        /// 兑币数
        ///</summary>
        [Display(Name="兑币数")]
        public int RefundQty { get; set; } // RefundQty

        ///<summary>
        /// 赠币数
        ///</summary>
        [Display(Name="赠币数")]
        public int OfferQty { get; set; } // OfferQty

        ///<summary>
        /// 币数(合计)
        ///</summary>
        [Display(Name="币数(合计)")]
        public int TotalQty { get; set; } // TotalQty

        ///<summary>
        /// 收银员名称
        ///</summary>
        [Display(Name="收银员名称")]
        public string UserName { get; set; } // UserName (length: 20)

        ///<summary>
        /// 充值金额
        ///</summary>
        [Display(Name="充值金额")]
        public decimal SaleAmt { get; set; } // SaleAmt

        ///<summary>
        /// 兑币金额
        ///</summary>
        [Display(Name="兑币金额")]
        public decimal RefundAmt { get; set; } // RefundAmt

        ///<summary>
        /// 合计金额
        ///</summary>
        [Display(Name="合计金额")]
        public decimal SumAmt { get; set; } // SumAmt

        ///<summary>
        /// 卡余币数(接班前)
        ///</summary>
        [Display(Name="卡余币数(接班前)")]
        public long TotalRestQtyBefor { get; set; } // TotalRestQtyBefor

        ///<summary>
        /// 卡余币数(交班后)
        ///</summary>
        [Display(Name="卡余币数(交班后)")]
        public long TotalRestQtyAfter { get; set; } // TotalRestQtyAfter

        ///<summary>
        /// 卡余币数(合计)
        ///</summary>
        [Display(Name="卡余币数(合计)")]
        public long TotalRestQty { get; set; } // TotalRestQty
        public System.DateTime OpTime { get; set; } // OpTime
        public string MangerCode { get; set; } // MangerCode (length: 50)
        public long? Ts { get; set; } // TS
        public int? ShiftId { get; set; } // ShiftId

        public ShiftRecord()
        {
            SaleQty = 0;
            RefundQty = 0;
            OfferQty = 0;
            TotalQty = 0;
            SaleAmt = 0m;
            RefundAmt = 0m;
            SumAmt = 0m;
            TotalRestQtyBefor = 0;
            TotalRestQtyAfter = 0;
            TotalRestQty = 0;
            OpTime = System.DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

    #endregion

    #region POCO Configuration

    // Customer
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class CustomerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
            : this("dbo")
        {
        }

        public CustomerConfiguration(string schema)
        {
            ToTable("Customer", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Code).HasColumnName(@"Code").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.NickName).HasColumnName(@"NickName").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Sex).HasColumnName(@"Sex").HasColumnType("int").IsRequired();
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Province).HasColumnName(@"Province").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Openid).HasColumnName(@"Openid").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Unionid).HasColumnName(@"Unionid").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.HeadImgUrl).HasColumnName(@"HeadImgUrl").HasColumnType("nvarchar").IsOptional().HasMaxLength(1000);
            Property(x => x.Score).HasColumnName(@"Score").HasColumnType("int").IsRequired();
            Property(x => x.CreateTime).HasColumnName(@"CreateTime").HasColumnType("datetime").IsRequired();
            Property(x => x.LastTime).HasColumnName(@"LastTime").HasColumnType("datetime").IsRequired();
            Property(x => x.IsStop).HasColumnName(@"IsStop").HasColumnType("bit").IsRequired();
            Property(x => x.IsManager).HasColumnName(@"IsManager").HasColumnType("bit").IsRequired();
            Property(x => x.Password).HasColumnName(@"Password").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // RegRecord
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class RegRecordConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RegRecord>
    {
        public RegRecordConfiguration()
            : this("dbo")
        {
        }

        public RegRecordConfiguration(string schema)
        {
            ToTable("RegRecord", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Record).HasColumnName(@"Record").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.GroundCode).HasColumnName(@"GroundCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.RegCode).HasColumnName(@"RegCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.CreateTime).HasColumnName(@"CreateTime").HasColumnType("datetime").IsRequired();
            Property(x => x.CreateUser).HasColumnName(@"CreateUser").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ShiftRecord
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class ShiftRecordConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ShiftRecord>
    {
        public ShiftRecordConfiguration()
            : this("dbo")
        {
        }

        public ShiftRecordConfiguration(string schema)
        {
            ToTable("ShiftRecord", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GroundCode).HasColumnName(@"GroundCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.CheckIn).HasColumnName(@"CheckIn").HasColumnType("datetime").IsOptional();
            Property(x => x.CheckOut).HasColumnName(@"CheckOut").HasColumnType("datetime").IsOptional();
            Property(x => x.SaleQty).HasColumnName(@"SaleQty").HasColumnType("int").IsRequired();
            Property(x => x.RefundQty).HasColumnName(@"RefundQty").HasColumnType("int").IsRequired();
            Property(x => x.OfferQty).HasColumnName(@"OfferQty").HasColumnType("int").IsRequired();
            Property(x => x.TotalQty).HasColumnName(@"TotalQty").HasColumnType("int").IsRequired();
            Property(x => x.UserName).HasColumnName(@"UserName").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
            Property(x => x.SaleAmt).HasColumnName(@"SaleAmt").HasColumnType("decimal").IsRequired().HasPrecision(18,2);
            Property(x => x.RefundAmt).HasColumnName(@"RefundAmt").HasColumnType("decimal").IsRequired().HasPrecision(18,2);
            Property(x => x.SumAmt).HasColumnName(@"SumAmt").HasColumnType("decimal").IsRequired().HasPrecision(18,2);
            Property(x => x.TotalRestQtyBefor).HasColumnName(@"TotalRestQtyBefor").HasColumnType("bigint").IsRequired();
            Property(x => x.TotalRestQtyAfter).HasColumnName(@"TotalRestQtyAfter").HasColumnType("bigint").IsRequired();
            Property(x => x.TotalRestQty).HasColumnName(@"TotalRestQty").HasColumnType("bigint").IsRequired();
            Property(x => x.OpTime).HasColumnName(@"OpTime").HasColumnType("datetime").IsRequired();
            Property(x => x.MangerCode).HasColumnName(@"MangerCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.Ts).HasColumnName(@"TS").HasColumnType("bigint").IsOptional();
            Property(x => x.ShiftId).HasColumnName(@"ShiftId").HasColumnType("int").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    #endregion

    #region Stored procedure return models

    #endregion

}
// </auto-generated>
