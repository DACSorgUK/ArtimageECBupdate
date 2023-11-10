<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoyaltyCalculator.ascx.cs"
    Inherits="DacsOnlineWebParts.WebParts.RoyaltyCalculator" %>
<script type="text/javascript">
    $(document).ready(function () {

        $(".FindOut").hide();

        if ($("#<%= salenotoccured.ClientID %>").attr('checked') == 'checked') {
            $(".saledate").hide();
        }
        else {
            $(".saledate").show();
        }

        if ($("#<%= salenotoccured.ClientID %>").attr('checked') == 'checked') {
            $(".saledate").hide();
        }
        else {
            $(".saledate").show();
        }


        $("#<%= salenotoccured.ClientID %>").change(function () {

            if ($("#<%= salenotoccured.ClientID %>").attr('checked') == 'checked') {
                $(".saledate").hide();
            }
            else {
                $(".saledate").show();
            }
        });

        $("#<%= AlreadySold.ClientID %>").change(function () {

            if ($("#<%= AlreadySold.ClientID %>").attr('checked') == 'checked') {
                $(".saledate").show();
            }
            else {
                $(".saledate").hide();
            }
        });

    });
</script>
<h1 class="pagetitle">
    ARR royalty calculator</h1>
<fieldset>
    <ol>
        <li>
            <fieldset class="options">
                <legend>Select sale status:</legend>
                <ul>
                    <li>
                        <asp:RadioButton ID="AlreadySold" name="AlreadySold" runat="server" Text="I have already sold this item"
                            GroupName="ArrGroup" ValidationGroup="valGroupArr" Checked="True" EnableViewState="true" />
                    </li>
                    <li>
                        <asp:RadioButton ID="salenotoccured" runat="server" Text="Sale has not yet occured"
                            GroupName="ArrGroup" ValidationGroup="valGroupArr" EnableViewState="true" /></li>
                </ul>
            </fieldset>
        </li>
        <div class="saledate">
            <li>
                <label for="sale-date">
                    Enter sale date:</label>
                <asp:TextBox ID="txtDate" runat="server" class="text date" ReadOnly="False" />
            </li>
        </div>
        <li>
            <label for="sale-price">
                Enter the sale price:</label>
            <div class="price">
                <asp:DropDownList ID="ddlCurrency" class="price-currency" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="TxtPrice" class="text third" runat="server"></asp:TextBox>
                <em class="red">
                    <asp:RequiredFieldValidator ID="reqValTxtPrice" runat="server" ErrorMessage="This field is mandatory, please enter"
                        ControlToValidate="TxtPrice"></asp:RequiredFieldValidator>
                </em>
            </div>
        </li>
    </ol>
    <div class="buttongroup">
        <asp:Button ID="Button1" class="button" runat="server" OnClick="Button1_Click" Text="Calculate" />
    </div>
    <!--/.buttongroup-->
</fieldset>
<div id="TextResult" visible="false" runat="server">
    <div class="boxout notification">
        <h2>
            For this sale, you will need to pay an ARR royalty of <strong>
                <asp:Label ID="LbResult" runat="server"></asp:Label>
            </strong>
        </h2>
        <h3>
            Sale amount: £<asp:Label ID="lblSalePricePounds" runat="server"></asp:Label>
            GBP or €
            <asp:Label ID="lblSalePriceEuro" runat="server"></asp:Label>
            EUR
        </h3>
        <ul>
            <li class="icon-tick" id="ECBSource" runat="server">If you use today's date, or a date
                in the future, the most recent available rate will be used for indicative purposes
                only. We update our rates from the official ECB source at 4.00pm daily, shortly
                after they become available.</li>
            <li class="icon-tick">This is above the €1,000 ARR threshold (on
                <asp:Label ID="lbDate" runat="server" Text=""></asp:Label>: 1 GBP =
                <asp:Label ID="lbExchangeEuro" runat="server" Text=""></asp:Label>
                EUR. source: ECB</li>
            <li class="icon-tick">You may wish to save this information or write it down for your
                own reference.</li>
            <li class="icon-tick">For further assistance contact <a href="mailto:arr@dacs.org.uk?subject=[DACS - ARR Enquiry]">arr@dacs.org.uk</a> or call
                0845 410 3410 (charged at local rates)</li>
        </ul>
        <a href='<%# HowIsCalculated %>'>Find out how this is calculated?</a>
    </div>
    <!--/.notification .success-->
    <div class="boxout">
        <h2>
            How to submit your sales details:</h2>
        <dl>
            <dt>Fill in a form online</dt>
            <dd>
                This is quick and easy if you have a small number of items to submit.</dd>
            <dt>Email us a spreadsheet or document</dt>
            <dd>
                This is most suitable if you have a large number of items to submit in bulk. We
                can accept any file type, but we recommend .doc, .xls, .txt or .csv.</dd>
            <dt>Post us your catalogue</dt>
            <dd>
                This is the most suitable method if you prefer not to use a computer. You can post
                a printed hard copy of your catalogue with your sales results to: Artist&#8217;s
                Resale Right Service, DACS, 33 Old Bethnal Green Road, London E2 3AA.</dd>
        </dl>
        <p>
            For assistance, email <a href="mailto:arr@dacs.org.uk?subject=[DACS - ARR Enquiry]">arr@dacs.org.uk</a> or call
            <strong>0845 410 3 410</strong>.</p>
    </div>
</div>
<div id="TxtErrortoofar" visible="false" runat="server">
    <div class="boxout notification">
        <h3>
            Sorry, we're not able to calculate the ARR fee for a sale date that far in the past</h3>
        <ul>
            <li class="icon-tick">For Futher assistance contact <a href="mailto:arr@dacs.org.uk?subject=[DACS - ARR Enquiry]">arr@dacs.org.uk</a> or call 0845 410
                3 410 (charged at local rates)</li>
        </ul>
    </div>
</div>
<div id="TxtErrorLess1000" visible="false" runat="server">
    <div class="boxout notification">
        <h3>
            The royalty due on such a sale would be €0.00 as the sale price falls below the
            threshold of €1,000.</h3>
        <ul>
            <li class="icon-tick">For Futher assistance contact <a href="mailto:arr@dacs.org.uk?subject=[DACS - ARR Enquiry]">arr@dacs.org.uk</a> or call 0845 410
                3 410 (charged at local rates)</li>
        </ul>
    </div>
</div>
