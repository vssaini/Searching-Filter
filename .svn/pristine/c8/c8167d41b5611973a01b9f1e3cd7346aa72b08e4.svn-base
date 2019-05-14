/*============================================
CHANGE CSS DYNAMICALLY
=============================================*/
function showAll(itemCount)
{
    $(document).ready(function ()
    {
        var div = document.getElementById("country");
        var resetText = 'Reset ' + (itemCount - 10);
        var showText = 'Show All ' + itemCount;

        if ($(div).hasClass('hide'))
        {
            $(div).animate({ height: $('#childcountry').height() }, 1000).addClass('show');
            $(div).removeClass('hide');
            $('#lblShow').text(resetText);
        }
        else
        {
            if ($(div).hasClass('show'))
            {
                $(div).animate({ height: 245 }, 1000).addClass('hide');
                $(div).removeClass('show');
                $('#lblShow').text(showText);
            }
        }

    });
}