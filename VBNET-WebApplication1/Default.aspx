<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VBNET_WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="updMain" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <main>                
                <div class="row">
                    <section class="col-md-7" aria-labelledby="gettingStartedTitle">
                        <h2 id="gettingStartedTitle">Tow listing</h2>
                        <p>
                            This is the list of tow jobs.
                        </p>
                        <p>
                            <p><a href="Default.aspx" class="btn btn-primary btn-md">Refresh</a></p>

                            <p>    
                                <asp:Button ID="btnAddNewRecord" CssClass="btn btn-primary btn-md" Enabled="true" runat="server" Text="Add New Record" />
                            </p>

                            <br />
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateSelectButton="True" BorderStyle="Solid" BorderWidth="2px" 
                                GridLines="Both"  DataKeyNames="TowID" CellSpacing="0" CellPadding="4">    
                                <RowStyle BorderStyle="Solid" BorderWidth="1px" />
                                <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
                                <SelectedRowStyle BackColor="#FFFF99" />
                            </asp:GridView>
                            <p>
                            </p>
                            <div>
                                <asp:Label ID="lblStatus" runat="server" ForeColor="#009900"></asp:Label>
                            </div>
                        </p>
                    </section>
                    <section class="col-md-3" aria-labelledby="librariesTitle">
                        <h2 id="dataTitle" runat="server">Tow Data</h2>
                        <p id="pSectionData" runat="server"></p>
                        <div id="divEditData" runat="server" class="disabled">
                            <p>
                                <asp:Label ID="lblCalledBy" runat="server" Text="Called By"></asp:Label><br />
                                <asp:TextBox ID="txtCalledBy" runat="server" Width="100%"></asp:TextBox>
                            </p>

                            <p>
                                <asp:Label ID="lblDriver" runat="server" Text="Driver"></asp:Label><br />
                                <asp:TextBox ID="txtDriver" runat="server" Width="100%"></asp:TextBox>
                            </p>
                
                            <p>
                                <asp:Label ID="lblVehicle" runat="server" Text="Vehicle"></asp:Label><br />
                                <asp:TextBox ID="txtVehicle" runat="server" Width="100%"></asp:TextBox>
                            </p>
                
                            <p>
                                <asp:Label ID="lblTowAddress" runat="server" Text="Tow Address"></asp:Label><br />
                                <asp:TextBox ID="txtTowAddress" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                            </p>
                
                            <p>
                                <asp:Label ID="lblTowLocation" runat="server" Text="Tow Location"></asp:Label><br />
                                <asp:TextBox ID="txtTowLocation" runat="server" Width="100%"></asp:TextBox>
                            </p>
                
                            <p>
                                <asp:Label ID="lblConatctPhone" runat="server" Text="Conatct Phone"></asp:Label><br />
                                <asp:TextBox ID="txtConatctPhone" runat="server" Width="100%"></asp:TextBox>
                            </p>
                
                            <p>
                                <asp:Label ID="lblCalledIn" runat="server" Text="Called In"></asp:Label><br />
                                <asp:TextBox ID="txtCalledInDate" runat="server" Width="50%" TextMode="Date"></asp:TextBox>
                                <asp:TextBox ID="txtCalledInTime" runat="server" Width="45%" TextMode="Time"></asp:TextBox>
                            </p>                

                        
                            <p>
                                <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label><br />
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </p>

                            <p>
                                <asp:Button ID="btnUpdate" Visible="false" CssClass="btn btn-primary btn-md" runat="server" Text="Update" />
                                <asp:Button ID="btnAdd" Visible="false" CssClass="btn btn-primary btn-md" runat="server" Text="Add" />
                                <asp:Button ID="btnCancel" Visible="false" CssClass="btn btn-secondary btn-md" runat="server" Text="Cancel" />
                            </p>
                            
                        </div>
                    </section>
                </div>
            </main>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
