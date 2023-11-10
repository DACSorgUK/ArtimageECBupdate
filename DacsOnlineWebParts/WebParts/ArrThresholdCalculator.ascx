<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArrThresholdCalculator.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.ArrThresholdCalculator" %>
<%--		change--%>
<%--<script>
   
</script>
<div class="breadcrumb">
    <h1>
        ARR threshold calculator</h1>
</div>--%>

<h1 class="pagetitle">
     ARR threshold calculator</h1>
<!--/.breadcrumb-->
<fieldset>
    <li class="icon-tick">Due to EU regulations, the ARR threshold is defined in € EUR.
    </li>
    <li class="icon-tick">Since the exchange rate varies daily, this tool allows you to
        calculate the ARR threshold in £ GBP for any given date. </li>
    <li>
        <div class="text date half">
            <label class="first-child" for="date">
                Sale date: </label>
            <div class="date">
                <asp:TextBox ID="txtDate" class="text date" runat="server" />
            </div>
             <em class="red">
                    <asp:RequiredFieldValidator ID="reqValTxtPrice" runat="server" ErrorMessage="This field is mandatory, please enter"
                        ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                </em>
        </div>
    </li>
    <div class="buttongroup">
        <asp:Button ID="Button2" CssClass="button" runat="server" OnClick="Button1_Click"
            Text="Calculate" />
    </div>
        <!--/.buttongroup-->
</fieldset>
<%--<asp:TextBox ID="TxtDate" runat="server"></asp:TextBox>--%>
<div id="TextResult" visible="false" runat="server">
    <div class="boxout notification">
        <h2>
            <strong>Date:<asp:Label ID="lbdateToday" runat="server"></asp:Label>
            <br />
                ARR Threshold: £<asp:Label ID="LbResult" runat="server"></asp:Label>
            </strong>
        </h2>
        <h3>
            On
            <asp:Label ID="lbdateToday2" runat="server"></asp:Label>, sales
            above 
            £<asp:Label ID="LbpriceGBP" runat="server"></asp:Label>
            may require an ARR payment.
        </h3>
        <ul>
            <h3>
                Details of this calculation:
            </h3>
              <li class="icon-tick" ID="ECBSource" runat="server">If you use today's date, or a date in the future, the most recent available rate will be used for indicative purposes only. We update our rates from the official ECB source at 4.00pm daily, shortly after they become available.</li>
            <li class="icon-tick">The ARR threshold is specified as €1000 EUR</li>
            <li class="icon-tick">According to the ECB, the exchange rate on
                <asp:Label ID="lbdateToday3" runat="server"></asp:Label>
                was £1=€<asp:Label ID="LbExchangeEuro" runat="server"></asp:Label>
            </li>
            <li class="icon-tick">Thus €1000/<asp:Label ID="LbExchangeEuro2" runat="server"></asp:Label>
                = £<asp:Label ID="LbResult1" runat="server"></asp:Label>
            </li>
        </ul>
    </div>
    <!--/.notification .success-->


</div>

<div id="TxtErrortoofar" visible="false" runat="server">
    <div class="boxout notification">
        <h3>
            Sorry, we're not able to calculate for date that far in the past</h3>
        <ul>
            <li class="icon-tick">For Futher assistance contact licensing@dacs.org.uk or call 0845 410
                3 410 (charged at local rates)</li>
        </ul>
    </div>
</div>
