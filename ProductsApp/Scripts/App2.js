
var uri = 'api/Orders';

$(document).on('pagebeforeshow ', '#pageone', function () {   // see: https://stackoverflow.com/questions/14468659/jquery-mobile-document-ready-vs-page-events

    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            var info_view = "";      //string to put HTML in
            $('#notes').empty();  // since I do this everytime the page is redone, I need to remove existing before apending them all again

            $.each(data, function (index, record) {   // make up each li as an <a> to the details-page
                $('#notes').append('<li><a data-transition="pop" data-parm=' + record.NoteId + ' href="#details-page">' + record.Priority + ' => ' + record.Subject + '</a></li>');
            });

            $("#notes").listview('refresh');  // need this so jquery mobile will apply the styling to the newly added li's

            $("a").on("click", function (event) {    // set up an event, if user clicks any, it writes that items data-parm into the 
                var parm = $(this).attr("data-parm");  // passing in the record.Id
                console.log(parm);
                //do something here with parameter on  details page
                $("#detailParmHere").html(parm);

            });


        });
});

    function find() {
        var id = $('#NoteId').val();
        $.getJSON(uri + '/' + id)
            .done(function (data) {
                $('#note').text(formatItem(data));
            })
            .fail(function (jqXHR, textStatus, err) {
                $('#note').text('Error: ' + err);
            });
    }
