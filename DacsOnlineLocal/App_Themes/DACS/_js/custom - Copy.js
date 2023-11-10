$(document).ready(function () {


    // var _ gaeventCategory = '';
    //  var _ gaeventCategory = '';
    $("body").on("click", ".gaEventTraking", function () {
        // $('.gaEventTraking').click(function () {
        //  console.log('GA Click--->');

        var _gaEventCategory = '';
        var _eventAction = '';
        var _gaEventLabel = '';
        var _eventPageId = 'p_lt_zoneDocument_pageplaceholder_pageplaceholder_lt_zoneRight_NewsLetterSignUpEvent_BtnSignup';
        var _newsPageId = 'p_lt_zoneDocument_pageplaceholder_pageplaceholder_lt_zoneRight_NewsLetterSignUpNews_BtnSignup';

        //  console.log('$(_eventId).length-->', $(_eventId).length);
        //   console.log('this.id-->', this.id);

        if (this.id == _eventPageId) {
            console.log('inside event');
            _gaEventCategory = 'Mailing list';
            _eventAction = 'Mailing list signup';
            _gaEventLabel = 'Subscribed for event updates';
        }
        else if (this.id == _newsPageId) {
            console.log('inside event');
            _gaEventCategory = 'Mailing list';
            _eventAction = 'Mailing list signup';
            _gaEventLabel = 'Subscribed for newsletter';
        }
        else if ($(this).hasClass('linkedin')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Follow';
            _gaEventLabel = 'Opened linkedin channel';
        }
        else if ($(this).hasClass('youtube')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Follow';
            _gaEventLabel = 'Opened youtube channel';
        }
        else if ($(this).hasClass('instagram')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Follow';
            _gaEventLabel = 'Opened instagram channel';
        }
        else if ($(this).hasClass('twitter')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Follow';
            _gaEventLabel = 'Opened twitter channel';
        }
        else if ($(this).hasClass('facebook')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Follow';
            _gaEventLabel = 'Opened facebook channel';
        }
        else if ($(this).hasClass('st_twitter_large')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Share';
            _gaEventLabel = 'Twitter share';
        }
        else if ($(this).hasClass('st_linkedin_large')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Share';
            _gaEventLabel = 'LinkedIn share';
        }
        else if ($(this).hasClass('st_facebook_large')) {
            _gaEventCategory = 'Social media';
            _eventAction = 'Share';
            _gaEventLabel = 'Facebook share';
        }
        else if (window.location.href.indexOf('/for-artists/payback') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened Payback artist form';
        }
        else if (window.location.href.indexOf('/for-beneficiaries-heirs/payback') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened Payback beneficiary form';
        }
        else if (window.location.href.indexOf('/for-artists/artists-resale-right/apply-online') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted ARR artist form';
        }
        else if (window.location.href.indexOf('/for-artists/artists-resale-right') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened ARR artist form';
        }
        else if (window.location.href.indexOf('/for-beneficiaries-heirs/artists-resale-right/register-your-interest') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted ARR beneficiary form';
        }
        else if (window.location.href.indexOf('/for-beneficiaries-heirs/artists-resale-right') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened ARR beneficiary form';
        }
        else if (window.location.href.indexOf('/for-artists/copyright-licensing/register-your-interest') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted CL artist form';
        }
        else if (window.location.href.indexOf('/for-artists/copyright-licensing') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened CL artist form';
        }
        else if (window.location.href.indexOf('/for-beneficiaries-heirs/copyright-licensing/register-your-interest') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted CL beneficiary form';
        }
        else if (window.location.href.indexOf('/for-beneficiaries-heirs/copyright-licensing') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Open form';
            _gaEventLabel = 'Opened CL beneficiary form';
        }
        else if (window.location.href.indexOf('/for-art-market-professionals/submit-your-sales-details') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted AMP form';
        }
        else if (window.location.href.indexOf('/knowledge-base/copyright-advice-for-artists') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted copyright advice enquiry';
        }
        else if (window.location.href.indexOf('/licensing-works/apply-online') > -1) {
            _gaEventCategory = 'Online form';
            _eventAction = 'Submit form';
            _gaEventLabel = 'Submitted licence enquiry';
        }


        if (window.location.href.indexOf('https://dev.dacs.org.uk/') > -1) {
            _gaEventCategory += ' -- DEV';
        }

        var obj = {
            hitType: 'event',
            eventCategory: _gaEventCategory,
            eventAction: _eventAction,
            eventLabel: _gaEventLabel,
            transport: 'beacon'
        };

        //$(this).attr('href')

        ga('send', obj);
        //console.log(obj);
        // return false;
    });

    $('.FormButton,.button,.icon.facebook.first-child.last-child,.icon.twitter.first-child.last-child,.icon.instagram.first-child.last-child,.icon.youtube.first-child.last-child,.icon.linkedin.first-child.last-child').addClass('gaEventTraking');


    $(".txtAtistnameSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{'term':'" + request.term + "'}",
                dataType: "json",
                url: window.location.protocol + "//" + window.location.hostname+"/CMSPages/WebService.asmx/ArtistSearch",
                async: true,
                success: function (data) {
                    //  console.table('D->',data.d);
                    response(data.d);
                },
                error: function (result) {
                    console.table(result);
                    // alert("Due to unexpected errors we were unable to load data");
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            // log("Selected: " + ui.item.value + " aka " + ui.item.id);
        }
    });

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    console.log('prm->',prm);

    prm.add_endRequest(function () {
        $(".txtAtistnameSearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{'term':'" + request.term + "'}",
                    dataType: "json",
                    url: window.location.protocol + "//" + window.location.hostname+"/CMSPages/WebService.asmx/ArtistSearch",
                    async: true,
                    success: function (data) {
                        //  console.table('D->',data.d);
                        response(data.d);
                    },
                    error: function (result) {
                        console.table(result);
                        // alert("Due to unexpected errors we were unable to load data");
                    }
                });
            },
            minLength: 2,
            select: function (event, ui) {
                // log("Selected: " + ui.item.value + " aka " + ui.item.id);
            }
        });
    });

});