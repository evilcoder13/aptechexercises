﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleChatWCF.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/WcfChatService")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> MessagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> Messages {
            get {
                return this.MessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.MessagesField, value) != true)) {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/WcfChatService")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SendTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SenderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SimpleChatWCF.ServiceReference1.User UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SendTime {
            get {
                return this.SendTimeField;
            }
            set {
                if ((this.SendTimeField.Equals(value) != true)) {
                    this.SendTimeField = value;
                    this.RaisePropertyChanged("SendTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SenderId {
            get {
                return this.SenderIdField;
            }
            set {
                if ((this.SenderIdField.Equals(value) != true)) {
                    this.SenderIdField = value;
                    this.RaisePropertyChanged("SenderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SimpleChatWCF.ServiceReference1.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISimpleChatService")]
    public interface ISimpleChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/Register", ReplyAction="http://tempuri.org/ISimpleChatService/RegisterResponse")]
        string Register(SimpleChatWCF.ServiceReference1.User usr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/Register", ReplyAction="http://tempuri.org/ISimpleChatService/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(SimpleChatWCF.ServiceReference1.User usr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/Login", ReplyAction="http://tempuri.org/ISimpleChatService/LoginResponse")]
        int Login(string Username, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/Login", ReplyAction="http://tempuri.org/ISimpleChatService/LoginResponse")]
        System.Threading.Tasks.Task<int> LoginAsync(string Username, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/SendMessage", ReplyAction="http://tempuri.org/ISimpleChatService/SendMessageResponse")]
        System.Nullable<System.DateTime> SendMessage(SimpleChatWCF.ServiceReference1.Message m);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/SendMessage", ReplyAction="http://tempuri.org/ISimpleChatService/SendMessageResponse")]
        System.Threading.Tasks.Task<System.Nullable<System.DateTime>> SendMessageAsync(SimpleChatWCF.ServiceReference1.Message m);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessages", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesResponse")]
        System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessages", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterId", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterIdResponse")]
        System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessagesAfterId(int _id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterId", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAfterIdAsync(int _id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterTime", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterTimeResponse")]
        System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessagesAfterTime(System.DateTime _dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterTime", ReplyAction="http://tempuri.org/ISimpleChatService/GetAllMessagesAfterTimeResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAfterTimeAsync(System.DateTime _dateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISimpleChatServiceChannel : SimpleChatWCF.ServiceReference1.ISimpleChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimpleChatServiceClient : System.ServiceModel.ClientBase<SimpleChatWCF.ServiceReference1.ISimpleChatService>, SimpleChatWCF.ServiceReference1.ISimpleChatService {
        
        public SimpleChatServiceClient() {
        }
        
        public SimpleChatServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimpleChatServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimpleChatServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimpleChatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Register(SimpleChatWCF.ServiceReference1.User usr) {
            return base.Channel.Register(usr);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(SimpleChatWCF.ServiceReference1.User usr) {
            return base.Channel.RegisterAsync(usr);
        }
        
        public int Login(string Username, string Password) {
            return base.Channel.Login(Username, Password);
        }
        
        public System.Threading.Tasks.Task<int> LoginAsync(string Username, string Password) {
            return base.Channel.LoginAsync(Username, Password);
        }
        
        public System.Nullable<System.DateTime> SendMessage(SimpleChatWCF.ServiceReference1.Message m) {
            return base.Channel.SendMessage(m);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<System.DateTime>> SendMessageAsync(SimpleChatWCF.ServiceReference1.Message m) {
            return base.Channel.SendMessageAsync(m);
        }
        
        public System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessages() {
            return base.Channel.GetAllMessages();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAsync() {
            return base.Channel.GetAllMessagesAsync();
        }
        
        public System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessagesAfterId(int _id) {
            return base.Channel.GetAllMessagesAfterId(_id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAfterIdAsync(int _id) {
            return base.Channel.GetAllMessagesAfterIdAsync(_id);
        }
        
        public System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message> GetAllMessagesAfterTime(System.DateTime _dateTime) {
            return base.Channel.GetAllMessagesAfterTime(_dateTime);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleChatWCF.ServiceReference1.Message>> GetAllMessagesAfterTimeAsync(System.DateTime _dateTime) {
            return base.Channel.GetAllMessagesAfterTimeAsync(_dateTime);
        }
    }
}
