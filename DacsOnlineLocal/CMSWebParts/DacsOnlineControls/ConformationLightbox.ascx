<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConformationLightbox.ascx.cs" Inherits="DacsOnlineWebParts.DacsOnlineControls.ConformationLightbox" %>
<div class="lightbox">
    <div class="notification lightbox-window">
        <h2>
            <strong>Artist Resale Right:</strong> Artist Search</h2>
        <p>
            You must accept the following terms and conditions before you can proceed:</p>
        <div class="boxout">
            <p>
                Whilst we endeavour to ensure that the information on this website is correct, we
                do not warrant its completeness or accuracy.</p>
            <p>
                Our Artist Search, found on our website, is intended as a guide and is correct to
                the best of our knowledge and research at the time of disclosure.</p>
            <p>
                Use of this web search does not imply partnership or any contractual relationship
                between DACS and the user.</p>
            <p>
                Nothing in this disclaimer (or elsewhere on our website) will exclude or limit our
                liability for fraud, for death or personal injury caused by our negligence, or for
                any other liability which cannot be excluded or limited under applicable law.</p>
        </div>
        <div>
            <label class="check">
                <input id="accept" type="checkbox" />
                I have read and understood these terms and conditions</label>
        </div>
        <div class="buttongroup">
            <input id="Proceed" class="button" type="button" value="Proceed" disabled="disabled" />
            <%--  <a id="Proceed1" class="button" href="#">Proceed</a> --%>
            <a class="hide-modal" href="#">Cancel</a>
        </div>
        <!--/.buttongroup-->
    </div>
</div>