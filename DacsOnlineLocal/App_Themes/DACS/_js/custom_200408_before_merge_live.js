$(document).ready(function () {

    var _gaEventCategory = 'DACS EVENT';
    // var _ gaeventCategory = '';
    //  var _ gaeventCategory = '';
    $( "body" ).on( "click", ".gaEventTraking", function() {
        // $('.gaEventTraking').click(function () {
        console.log('GA Click--->');

        var _eventAction = $(this).text().trim();

        if(_eventAction.trim() =='')
            _eventAction = $(this).val().trim();

        var obj = {
            hitType: 'event',
            eventCategory: _gaEventCategory,
            eventAction: _eventAction,
            eventLabel: window.location.href,
            transport: 'beacon'

        };

        //$(this).attr('href')

        ga('send', obj);
        //console.log(obj);
        // return false;
    });

    $('.FormButton,.button').addClass('gaEventTraking');

    ////////////////////////// GOOGLE ANALAYTICS END ////////////

    //$('.LogoHome').bicubicImgInterpolation({
    //    crossOrigin: 'anonymous' //only for demo purpose (external img source is requested) otherwise browser security error is triggered
    //});

    // code for twitter image load

   // var imagePath = $("[id$='_imgImage']").attr('src');

   // if (imagePath == undefined)
   //     imagePath = '/App_Themes/DACS/_assets/hallmark-172x48.png';

   // var content = $('meta[name="twitter:image"]').attr('content');
   // console.log('PRV->',content);
   // content = content.replace('IMAGECODEURL', imagePath);
   //$('meta[name="twitter:image"]').attr('content', content);

   //// $('meta[name="twitter:image"]').replaceWith('<meta name="twitter:image" content="' + content + '">');

    console.log('CUR->',$('meta[name="twitter:image"]').attr('content'));
   // //console.log(imagePath);
});