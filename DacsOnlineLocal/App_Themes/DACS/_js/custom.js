$(document).ready(function () {

   
    // var _ gaeventCategory = '';
    //  var _ gaeventCategory = '';
    $("body").on("click", ".gaEventTraking", function () {
        // $('.gaEventTraking').click(function () {
        //  console.log('GA Click--->');

        try {
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
            else if (window.location.href.indexOf('/licensing-works/enquiry') > -1) {
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
        }
        catch (err) {
            console.log(err);
        }

      
    });

    $('.FormButton,.button,.icon.facebook.first-child.last-child,.icon.twitter.first-child.last-child,.icon.instagram.first-child.last-child,.icon.youtube.first-child.last-child,.icon.linkedin.first-child.last-child').addClass('gaEventTraking');


    //$(".txtAtistnameSearch").autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            type: "POST",
    //            contentType: "application/json; charset=utf-8",
    //            data: "{'term':'" + request.term + "'}",
    //            dataType: "json",
    //            url: window.location.protocol + "//" + window.location.hostname+"/CMSPages/WebService.asmx/ArtistSearch",
    //            async: true,
    //            success: function (data) {
    //                //  console.table('D->',data.d);
    //                response(data.d);
    //            },
    //            error: function (result) {
    //                console.table(result);
    //                // alert("Due to unexpected errors we were unable to load data");
    //            }
    //        });
    //    },
    //    minLength: 2,
    //    select: function (event, ui) {
    //        // log("Selected: " + ui.item.value + " aka " + ui.item.id);
    //    }
    //});

    var prm = Sys.WebForms.PageRequestManager.getInstance();

   // console.log('prm->',prm);

    prm.add_endRequest(function () {
        //$(".txtAtistnameSearch").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            type: "POST",
        //            contentType: "application/json; charset=utf-8",
        //            data: "{'term':'" + request.term + "'}",
        //            dataType: "json",
        //            url: window.location.protocol + "//" + window.location.hostname+"/CMSPages/WebService.asmx/ArtistSearch",
        //            async: true,
        //            success: function (data) {
        //                //  console.table('D->',data.d);
        //                response(data.d);
        //            },
        //            error: function (result) {
        //                console.table(result);
        //                // alert("Due to unexpected errors we were unable to load data");
        //            }
        //        });
        //    },
        //    minLength: 2,
        //    select: function (event, ui) {
        //        // log("Selected: " + ui.item.value + " aka " + ui.item.id);
        //    }
        //});
        $('.ddlAtistnameSearch').select2({
            ajax: {
                minimumInputLength: 3,
                type: "POST",
                delay: 1000,
                contentType: "application/json; charset=utf-8",
                //data: "{'term':'" + params.term + "'}",
                data: function (params) {
                    return "{'term':'" + params.term + "'}"
                },
                dataType: "json",
                url: window.location.protocol + "//" + window.location.hostname + "/CMSPages/WebService.asmx/ArtistSearch",
                async: true,
                processResults: function (data) {
                    // Transforms the top-level key of the response object from 'items' to 'results'
                    console.log('a');
                    return {
                        results: data.d
                    };
                }
            }
        });

        $('.ddlAtistnameSearch').on('select2:select', function (e) {
            var data = e.params.data;
           
           // console.log('data seleted', data);
            $('#hdnddlAtistname').val(data.text);
            $('#hdnddlAtistId').val(data.id);
        });
    });

    $('.ddlAtistnameSearch').select2({
        minimumInputLength: 3,
        delay: 1000,
        ajax: {
            type: "POST",
            delay: 'fast',
            contentType: "application/json; charset=utf-8",
            //data: "{'term':'" + params.term + "'}",
            data: function (params) {
                return "{'term':'" + params.term + "'}"
            },
            dataType: "json",
            url: window.location.protocol + "//" + window.location.hostname + "/CMSPages/WebService.asmx/ArtistSearch",
            async: true,
            processResults: function (data) {
                console.log('0');
                return {
                    results: data.d
                };
            }
        }
    });

    $('.ddlAtistnameSearch').on('select2:select', function (e) {
        var data = e.params.data;
       // console.log('data seleted', data);
        $('#hdnddlAtistname').val(data.text);
        $('#hdnddlAtistId').val(data.id);
    });


    $("#btnUpload").on('click', function () {
        var formData = new FormData();
        var fileUpload = $('#files').get(0);
        var files = fileUpload.files;
        for (var i = 0; i < files.length; i++) {
           // console.log('files.length', files[i]);
           // console.log(files[i].name);
            formData.append(files[i].name, files[i]);
        }
        $.ajax({
            url: window.location.protocol + "//" + window.location.hostname + "/CMSPages/WebService.asmx/Upload",
            type: 'POST',
            data: formData,
            beforeSend: function () {
                // Show image container
                $("#imgLoader").show();
            },
            success: function (data) {
                console.log('files.length', files[0].size);
                for (var i = 0; i < files.length; i++) {
                    let fileiIze = files[i].size;
                    let fileName = files[i].name;

                    let _contentLength = (fileiIze / (1024)).toFixed(2);
                    var text = _contentLength + " KB";

                    if (_contentLength > (1024)) {
                        text = (_contentLength / 1024).toFixed(2) + " MB";
                    }

                    //if (contentType.length > 0) {
                    //    text += ", '" + contentType + "'";
                    //}
                    addToClientTable(fileName, text);
                }

            },
            error: function (data) {
               // alert('error' + data)
                let fileName = files[0].name;
                addToClientTable(args.get_fileName(), "<span style='color:red;'>" + data + "</span>");
            },
            complete: function (data) {
                // Hide image container
                $("#imgLoader").hide();
            },
            cache: false,
            contentType: false,
            processData: false,
            xhr: function () {
                var xhr = new window.XMLHttpRequest();
                xhr.upload.addEventListener("progress", function (evt) {
                    if (evt.lengthComputable) {
                        var percentComplete = Math.round((evt.loaded / evt.total) * 100);

                        //$('.progress-bar').css('width', percentComplete + '%').attr('aria-valuenow', percentComplete);
                        //$('.progress-bar').text(percentComplete + '%');
                        //console.log(percentComplete);
                    }
                }, false);
                return xhr;
            },
        });
    });


   // $('.addtooltip').tooltip({ show: { effect: "none", delay: 0 } });

});