<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS401000.aspx.cs" Inherits="Page_RS401000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVPaymentPlanInq"
        PageLoadBehavior="PopulateSavedValues"
        PrimaryView="Filter">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Filter" Width="100%" Height="100px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule LabelsWidth="XM" ID="PXLayoutRule1" runat="server" StartColumn="True" />
            <px:PXSegmentMask CommitChanges="True" runat="server" ID="CstPXSegmentMask1" DataField="CustomerID"/>
            <px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector2" DataField="ServiceID" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="DetailsView">
                <Columns>
                    <px:PXGridColumn DataField="OrderNbr" Width="72" />
                    <px:PXGridColumn DataField="Status" Width="140" />
                    <px:PXGridColumn DataField="InvoiceNbr" Width="72" />
                    <px:PXGridColumn DataField="PercentPaid" Width="72" />
                    <px:PXGridColumn DataField="ARInvoice__DueDate" Width="72" />
                    <px:PXGridColumn DataField="ARInvoice__CuryDocBal" Width="100" />

                    <px:PXGridColumn DataField="OrderType" Width="72"/>

                    <px:PXGridColumn DataField="ServiceID" Width="100" />
                    <px:PXGridColumn DataField="CustomerID" Width="85" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
        <ActionBar>
        </ActionBar>
    </px:PXGrid>
</asp:Content>
