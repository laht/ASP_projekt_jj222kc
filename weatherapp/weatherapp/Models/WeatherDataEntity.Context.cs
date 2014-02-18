﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace weatherapp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class WP12_jj222kc_weatherAppEntities : DbContext
    {
        public WP12_jj222kc_weatherAppEntities()
            : base("name=WP12_jj222kc_weatherAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Position> Positions { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspAddPosition(string name, Nullable<double> lat, Nullable<double> lng)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var latParameter = lat.HasValue ?
                new ObjectParameter("Lat", lat) :
                new ObjectParameter("Lat", typeof(double));
    
            var lngParameter = lng.HasValue ?
                new ObjectParameter("Lng", lng) :
                new ObjectParameter("Lng", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspAddPosition", nameParameter, latParameter, lngParameter);
        }
    
        public virtual int uspAddWeather(Nullable<double> temperature, Nullable<System.DateTime> validtime, string city, Nullable<int> symbol, Nullable<int> positionId, Nullable<System.DateTime> nextUpdate)
        {
            var temperatureParameter = temperature.HasValue ?
                new ObjectParameter("Temperature", temperature) :
                new ObjectParameter("Temperature", typeof(double));
    
            var validtimeParameter = validtime.HasValue ?
                new ObjectParameter("Validtime", validtime) :
                new ObjectParameter("Validtime", typeof(System.DateTime));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var symbolParameter = symbol.HasValue ?
                new ObjectParameter("Symbol", symbol) :
                new ObjectParameter("Symbol", typeof(int));
    
            var positionIdParameter = positionId.HasValue ?
                new ObjectParameter("PositionId", positionId) :
                new ObjectParameter("PositionId", typeof(int));
    
            var nextUpdateParameter = nextUpdate.HasValue ?
                new ObjectParameter("NextUpdate", nextUpdate) :
                new ObjectParameter("NextUpdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddWeather", temperatureParameter, validtimeParameter, cityParameter, symbolParameter, positionIdParameter, nextUpdateParameter);
        }
    
        public virtual int uspRemoveWeather(Nullable<int> positionId)
        {
            var positionIdParameter = positionId.HasValue ?
                new ObjectParameter("PositionId", positionId) :
                new ObjectParameter("PositionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspRemoveWeather", positionIdParameter);
        }
    
        public virtual int uspUpdateWeather(Nullable<int> id, Nullable<double> temperature, string city, Nullable<short> symbol, Nullable<int> positionId, Nullable<System.DateTime> validTime, Nullable<System.DateTime> nextUpdate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var temperatureParameter = temperature.HasValue ?
                new ObjectParameter("Temperature", temperature) :
                new ObjectParameter("Temperature", typeof(double));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var symbolParameter = symbol.HasValue ?
                new ObjectParameter("Symbol", symbol) :
                new ObjectParameter("Symbol", typeof(short));
    
            var positionIdParameter = positionId.HasValue ?
                new ObjectParameter("PositionId", positionId) :
                new ObjectParameter("PositionId", typeof(int));
    
            var validTimeParameter = validTime.HasValue ?
                new ObjectParameter("ValidTime", validTime) :
                new ObjectParameter("ValidTime", typeof(System.DateTime));
    
            var nextUpdateParameter = nextUpdate.HasValue ?
                new ObjectParameter("NextUpdate", nextUpdate) :
                new ObjectParameter("NextUpdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateWeather", idParameter, temperatureParameter, cityParameter, symbolParameter, positionIdParameter, validTimeParameter, nextUpdateParameter);
        }
    
        public virtual ObjectResult<string> uspGetPositionByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetPositionByName", nameParameter);
        }
    
        public virtual int uspRemovePosition(Nullable<int> positionId)
        {
            var positionIdParameter = positionId.HasValue ?
                new ObjectParameter("PositionId", positionId) :
                new ObjectParameter("PositionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspRemovePosition", positionIdParameter);
        }
    
        public virtual int uspUpdatePosition(Nullable<int> id, string name, Nullable<double> lat, Nullable<double> lng)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var latParameter = lat.HasValue ?
                new ObjectParameter("Lat", lat) :
                new ObjectParameter("Lat", typeof(double));
    
            var lngParameter = lng.HasValue ?
                new ObjectParameter("Lng", lng) :
                new ObjectParameter("Lng", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdatePosition", idParameter, nameParameter, latParameter, lngParameter);
        }
    }
}
