<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.Confirmation" %>
<h1 class="pagetitle">
    <asp:Label ID="LbFormName1" runat="server" Text=""></asp:Label></h1>
<div class="notification success">
    <h2>Your form has been submitted
    </h2>
    <div>
        <p>
            Thank you for
           <strong>
               <asp:Label ID="lbFormName2" runat="server" Text=""></asp:Label>.</strong>
        </p>
    </div>
    <div>
        <p>
            Someone from DACS will be in touch within 
            <% if (HttpContext.Current.Request.RawUrl.ToLower().Contains("submit-your-sales-details"))
                { %>
            3 working days.
             <% }
                 else if (HttpContext.Current.Request.RawUrl.ToLower().Contains("copyright-advice-for-artists"))
                 { %>
            2 working days.
            <% }
                else
                { %>
            1 working day.
            <%} %>
             We have emailed
            you <strong>(<asp:Label ID="LbemailUser" runat="server" Text=""></asp:Label>)</strong> a copy of
            your application. Your reference number is
            <asp:Label ID="lbReference" runat="server" Text=""></asp:Label>.
        </p>
    </div>
    <% if (!HttpContext.Current.Request.RawUrl.ToLower().Contains("copyright-advice-for-artists"))
        { %>
    <div>
        <p>
            <strong>Want to follow up on your
                <asp:Label ID="lbFollowon" runat="server" Text=""></asp:Label>?</strong>
        </p>
        <p>
            - email <strong><a class="first-child" href='mailto:<%# FormEmail %>?subject=DACS'></strong>
            <asp:Label ID="lbemaildacs" runat="server" Text=""></asp:Label></a>
        </p>
        <p>
            - phone <strong class="last-child">
                <asp:Label ID="lbphone" runat="server" Text=""></asp:Label></strong>
        </p>
    </div>
    <%} %>
</div>
