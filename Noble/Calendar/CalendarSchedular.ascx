<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarSchedular.ascx.cs"
    Inherits="Noble.Calendar.CalendarSchedular" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="evtScheduler">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1">
                </telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadScheduler ID="RadScheduler1" runat="server" Width="800px" DataKeyField="EVENT_ID"
    AllowDelete="true" AllowEdit="true" Skin="WebBlue" DataStartField="START_DATE" DataSubjectField="EVENT_DESC"
    DataEndField="END_DATE" AdvancedForm-Modal="true" SelectedView="MonthView" StartInsertingInAdvancedForm="true"
    StartEditingInAdvancedForm="true" AdvancedForm-Enabled="true" AdvancedForm-EnableResourceEditing="true"
    OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" 
    onappointmentdelete="RadScheduler1_AppointmentDelete" 
    onappointmentinsert="RadScheduler1_AppointmentInsert">
</telerik:RadScheduler>
