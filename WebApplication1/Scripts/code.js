

const input = $("#input");
const input$ = Rx.Observable.fromEvent(input, 'keyup')
    .throttleTime(250)
    .map(key => Rx.getJSON("/searchResults?q="+input.value));
input$
    .subscribe(
    (e) => {
        console.log("x");
    });

$("#input").on('keyup', function (e) {
    console.log(e);

    $.ajax({
        method: "GET",
        url: '/Home/AutoComplete',
        data: {input: $("#input").val()},
        success: function (data) {
            
            console.log("data=" + data);
            $("#select").empty();
            if (data) {
                if (data.length === 0) {
                    $("#autocompletediv").hide();
                } else {
                    $("#autocompletediv").show();
                    $("#select").attr("size", Math.max(4, data.length));
                    $.each(data, (i, item) => {
                        console.log(i + " " + item);
                        $("#select").append($('<option>', {
                            value: i,
                            text: item
                        }))
                    });
                }
            }
        }
    });
});