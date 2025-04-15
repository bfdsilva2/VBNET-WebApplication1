<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VBNET_WebApplication1._Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>        

        <div class="row">
            <section class="col-md-7" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Tow listing</h2>
                <p>
                    This is the list of tow jobs.
                </p>
                <p>                    
                    <p><a href="Default.aspx" class="btn btn-primary btn-md">Refresh</a></p>
                    <br />
                    <asp:GridView ID="gvMain" runat="server" AutoGenerateSelectButton="True" BorderStyle="Solid" BorderWidth="3px" DataKeyNames="TowID">
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>

                </p>
            </section>
            <section class="col-md-3" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Edit Data</h2>
                <p>
                    You can edit selected data in this section.</p>
                <p>
                    <asp:Label ID="lblCalledBy" runat="server" Text="Called By"></asp:Label>
                    <asp:TextBox ID="txtCalledBy" runat="server" Width="100%"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="lblDriver" runat="server" Text="Driver"></asp:Label>
                    <asp:TextBox ID="txtDriver" runat="server" Width="100%"></asp:TextBox>
                </p>
                
                <p>
                    <asp:Label ID="lblVehicle" runat="server" Text="Vehicle"></asp:Label>
                    <asp:TextBox ID="txtVehicle" runat="server" Width="100%"></asp:TextBox>
                </p>
                
                <p>
                    <asp:Label ID="lblTowAddress" runat="server" Text="Tow Address"></asp:Label>
                    <asp:TextBox ID="txtTowAddress" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                </p>
                
                <p>
                    <asp:Label ID="lblTowLocation" runat="server" Text="Tow Location"></asp:Label>
                    <asp:TextBox ID="txtTowLocation" runat="server" Width="100%"></asp:TextBox>
                </p>
                
                <p>
                    <asp:Label ID="lblConatctPhone" runat="server" Text="Conatct Phone"></asp:Label>
                    <asp:TextBox ID="txtConatctPhone" runat="server" Width="100%"></asp:TextBox>
                </p>
                
                <p>
                    <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                    <asp:TextBox ID="txtNotes" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                </p>                

                <p><asp:Button ID="btnUpdate" runat="server" Text="Update" /></p>

            </section>
          <%--  <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>--%>
        </div>
    </main>

</asp:Content>
