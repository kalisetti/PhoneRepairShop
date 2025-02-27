<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS301000.aspx.cs" Inherits="Page_RS301000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVWorkOrderEntry"
        PrimaryView="WorkOrders">
        <CallbackCommands>
            <px:PXDSCallbackCommand Visible="false" CommitChanges="true" Name="Complete"></px:PXDSCallbackCommand>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="WorkOrders" Width="100%" Height="200px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True" ControlSize="SM" LabelsWidth="S"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector15" DataField="OrderNbr" TextMode="Editable"></px:PXSelector>
            <px:PXDropDown CommitChanges="True" runat="server" ID="CstPXDropDown13" DataField="Status"></px:PXDropDown>
            <px:PXCheckBox CommitChanges="True" runat="server" ID="CstPXCheckBox7" DataField="Hold"></px:PXCheckBox>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit4" DataField="DateCreated" Size="SM"></px:PXDateTimeEdit>
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit3" DataField="DateCompleted" Size="SM"></px:PXDateTimeEdit>
            <px:PXLayoutRule runat="server" ColumnSpan="3" />
            <px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="Description"></px:PXTextEdit>

            <px:PXLayoutRule runat="server" ID="CstPXLayoutRule14" StartColumn="True" ControlSize="SM" LabelsWidth="S" />
            <px:PXSegmentMask runat="server" ID="CstPXSegmentMask2" DataField="CustomerID"></px:PXSegmentMask>
            <px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector12" DataField="ServiceID"></px:PXSelector>
            <px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector6" DataField="DeviceID"></px:PXSelector>
            <px:PXSelector runat="server" ID="CstPXSelector5" DataField="Assignee"></px:PXSelector>
            <px:PXDropDown runat="server" ID="CstPXDropDown11" DataField="Priority"></px:PXDropDown>

            <px:PXLayoutRule runat="server" ID="CstPXLayoutRule15" StartColumn="True" ControlSize="SM" LabelsWidth="S" />
            <px:PXNumberEdit runat="server" ID="CstPXNumberEdit10" DataField="OrderTotal" Size="SM"></px:PXNumberEdit>
            <px:PXSelector runat="server" ID="CstPXTextEdit8" DataField="InvoiceNbr" Enabled="False" AllowEdit="True"></px:PXSelector>
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="true">
        <Items>
            <px:PXTabItem Text="Repair Items">
                <Template>
                    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false" AutoSize="true" SyncPosition="True">
                        <Levels>
                            <px:PXGridLevel DataMember="RepairItems">
                                <RowTemplate>
                                    <px:PXLayoutRule ID="PXLayoutRule20" runat="server" StartRow="True"></px:PXLayoutRule>
                                    <px:PXLayoutRule ID="PXLayoutRule25" runat="server" LabelsWidth="SM" ControlSize="M"
                                        GroupCaption="Repair Item" StartGroup="True">
                                    </px:PXLayoutRule>
                                    <px:PXDropDown runat="server" ID="CstPXDropDown27" DataField="RepairItemType"></px:PXDropDown>
                                    <px:PXSegmentMask runat="server" ID="CstPXSegmentMask8" DataField="InventoryID" AutoRefresh="true"></px:PXSegmentMask>
                                    <px:PXTextEdit runat="server" ID="CstPXTextEdit26" DataField="InventoryID_description"></px:PXTextEdit>

                                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule30" LabelsWidth="S"
                                        GroupCaption="Price info" StartColumn="True">
                                    </px:PXLayoutRule>
                                    <px:PXNumberEdit runat="server" ID="CstPXNumberEdit25" DataField="BasePrice"></px:PXNumberEdit>
                                </RowTemplate>
                                <Columns>
                                    <px:PXGridColumn DataField="RepairItemType" CommitChanges="True" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="InventoryID" CommitChanges="True" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="InventoryID_description" Width="280"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" DataField="BasePrice" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn Type="CheckBox" DataField="IsDefault" CommitChanges="true" Width="80"></px:PXGridColumn>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
                        <ActionBar>
                        </ActionBar>

                        <Mode AllowFormEdit="True"></Mode>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Labor">
                <Template>
                    <px:PXGrid ID="gridLabor" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false" AutoSize="true" SyncPosition="True">
                        <Levels>
                            <px:PXGridLevel DataMember="Labor">
                                <Columns>
                                    <px:PXGridColumn DataField="InventoryID" CommitChanges="True" Width="70"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="InventoryID_description" Width="280"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="DefaultPrice" CommitChanges="True" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Quantity" CommitChanges="True" Width="100"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="ExtPrice" Width="100"></px:PXGridColumn>

                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
                        <ActionBar>
                            <CustomItems>
                                <px:PXToolBarButton Text="Complete">
                                    <AutoCallBack Command="Complete" Target="ds">
                                        <Behavior CommitChanges="True"></Behavior>
                                    </AutoCallBack>
                                </px:PXToolBarButton>
                            </CustomItems>
                        </ActionBar>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Payment Info">
                <Template>
                    <px:PXFormView DataMember="Payments" runat="server" ID="formPayments">
                        <Template>
                            <px:PXTextEdit runat="server" ID="CstPXTextEdit32" DataField="InvoiceNbr"></px:PXTextEdit>
                            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit31" DataField="DueDate"></px:PXDateTimeEdit>
                            <px:PXTextEdit runat="server" ID="CstPXTextEdit29" DataField="AdjgRefNbr"></px:PXTextEdit>
                            <px:PXNumberEdit runat="server" ID="CstPXNumberEdit30" DataField="CuryAdjdAmt"></px:PXNumberEdit>
                        </Template>
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
    </px:PXTab>
</asp:Content>
