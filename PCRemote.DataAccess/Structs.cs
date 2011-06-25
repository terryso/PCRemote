


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace PCRemote.DataAccess {
	
        /// <summary>
        /// Table: sqlite_sequence
        /// Primary Key: 
        /// </summary>

        public class sqlite_sequenceTable: DatabaseTable {
            
            public sqlite_sequenceTable(IDataProvider provider):base("sqlite_sequence",provider){
                ClassName = "sqlite_sequence";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("seq", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
            				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
           
            public IColumn seq{
                get{
                    return this.GetColumn("seq");
                }
            }
            				
   			public static string seqColumn{
			      get{
        			return "seq";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: Commands
        /// Primary Key: 
        /// </summary>

        public class CommandsTable: DatabaseTable {
            
            public CommandsTable(IDataProvider provider):base("Commands",provider){
                ClassName = "Command";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("CommandName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });

                Columns.Add(new DatabaseColumn("File", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647
                });
                    
                
                
            }
            
            public IColumn CommandName{
                get{
                    return this.GetColumn("CommandName");
                }
            }
            				
   			public static string CommandNameColumn{
			      get{
        			return "CommandName";
      			}
		    }
           
            public IColumn File{
                get{
                    return this.GetColumn("File");
                }
            }
            				
   			public static string FileColumn{
			      get{
        			return "File";
      			}
		    }
           
                    
        }
        
}