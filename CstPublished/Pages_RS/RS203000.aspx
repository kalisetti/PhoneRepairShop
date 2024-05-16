<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="RS203000.aspx.cs" Inherits="Page_RS203000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="PhoneRepairShop.RSSVRepairPriceMaint"
        PrimaryView="RepairPrices">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="RepairPrices" Width="100%" Height="100px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"
                ControlSize="M"
                LabelsWidth="S">
            </px:PXLayoutRule>
            <px:PXSelector ID="ServiceID" runat="server" DataField="ServiceID">
            </px:PXSelector>
            <px:PXSelector ID="DeviceID" runat="server" DataField="DeviceID">
            </px:PXSelector>

            <px:PXLayoutRule ID="PXLayoutRule2" runat="server" StartColumn="True"
                ControlSize="M"
                LabelsWidth="S">
            </px:PXLayoutRule>
            <px:PXNumberEdit ID="Price" runat="server" DataField="Price">
            </px:PXNumberEdit>
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
        <Items>
            <px:PXTabItem Text="Repair Items">
                <Template>
                    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false" AutoSize="true">
                        <Levels>
                            <px:PXGridLevel DataMember="RepairItems">
                                <Columns>
                                    <px:PXGridColumn DataField="RepairItemType" Width="70"/>
                                    <px:PXGridColumn Type="CheckBox" DataField="Required" Width="80"/>
                                    <px:PXGridColumn DataField="InventoryID" Width="70"/>
                                    <px:PXGridColumn DataField="InventoryID_description" Width="280"/>
                                    <px:PXGridColumn DataField="BasePrice" Width="100"/>
                                    <px:PXGridColumn Type="CheckBox" DataField="IsDefault" Width="80"/>

                                   <%-- <px:PXGridColumn Type="CheckBox" DataField="Active" Width="60"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" Type="CheckBox" DataField="WalkInService" Width="60"></px:PXGridColumn>
                                    <px:PXGridColumn Type="CheckBox" DataField="Prepayment" Width="60"></px:PXGridColumn>
                                    <px:PXGridColumn CommitChanges="True" Type="CheckBox" DataField="PreliminaryCheck" Width="60"></px:PXGridColumn>--%>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
                        <ActionBar>
                        </ActionBar>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Labor">
                <Template>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Warranty">
                <Template>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
    </px:PXTab>
</asp:Content>
