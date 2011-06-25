


using System;
using System.ComponentModel;
using System.Linq;

namespace PCRemote.DataAccess
{
    
    
    
    
    /// <summary>
    /// A class which represents the sqlite_sequence table in the PCRemote Database.
    /// This class is queryable through PCRemoteDB.sqlite_sequence 
    /// </summary>

	public partial class sqlite_sequence: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public sqlite_sequence(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
		
		private string _name;
		public string name { 
		    get{
		        return _name;
		    } 
		    set{
		        this.OnnameChanging(value);
                this.SendPropertyChanging();
                this._name = value;
                this.SendPropertyChanged("name");
                this.OnnameChanged();
		    }
		}
		
        partial void OnseqChanging(string value);
        partial void OnseqChanged();
		
		private string _seq;
		public string seq { 
		    get{
		        return _seq;
		    } 
		    set{
		        this.OnseqChanging(value);
                this.SendPropertyChanging();
                this._seq = value;
                this.SendPropertyChanged("seq");
                this.OnseqChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
    
    
    /// <summary>
    /// A class which represents the Commands table in the PCRemote Database.
    /// This class is queryable through PCRemoteDB.Command 
    /// </summary>

	public partial class Command: INotifyPropertyChanging, INotifyPropertyChanged
	{
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
	    
	    public Command(){
	        OnCreated();
	    }
	    
	    #region Properties
	    
        partial void OnCommandNameChanging(string value);
        partial void OnCommandNameChanged();
		
		private string _CommandName;
		public string CommandName { 
		    get{
		        return _CommandName;
		    } 
		    set{
		        this.OnCommandNameChanging(value);
                this.SendPropertyChanging();
                this._CommandName = value;
                this.SendPropertyChanged("CommandName");
                this.OnCommandNameChanged();
		    }
		}
		
        partial void OnFileChanging(string value);
        partial void OnFileChanged();
		
		private string _File;
		public string File { 
		    get{
		        return _File;
		    } 
		    set{
		        this.OnFileChanging(value);
                this.SendPropertyChanging();
                this._File = value;
                this.SendPropertyChanged("File");
                this.OnFileChanged();
		    }
		}
		

        #endregion

        #region Foreign Keys
        #endregion


        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            var handler = PropertyChanging;
            if (handler != null)
               handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

	}
	
}