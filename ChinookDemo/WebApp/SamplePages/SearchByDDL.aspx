﻿<%@ Page Title="Filter Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class ="row">
        <asp:Label ID="Label1" runat="server" Text="Select an artist"></asp:Label>
        <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>
        <asp:LinkButton ID="SearchAlbum" runat="server">Search for albums</asp:LinkButton>
    </div>
    <div class ="row">
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
