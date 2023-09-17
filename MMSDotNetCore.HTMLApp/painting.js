function run(){
    // const painting={
    //     PaintingName:"The Lock",
    //     PaintingType:"Oil",
    //     PaintingPrice:800000
    // }
    // createPainting(painting);
    //updatePainting(2007);
    deletePainting(2003);
    //readPainting();
    //editPainting(2009);
    //updatePainting(2010,painting)
    //readPainting();
}
function readPainting(){
    const url = 'https://localhost:7146/api/PaintingModel';
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            console.log(data);

            $.each(data, function (index, paintingModel) {
                console.log({ paintingModel });
                console.log(paintingModel.PaintingName);
                console.log(paintingModel.PaintingType);
                console.log(paintingModel.PaintingPrice);
                console.log(paintingModel.PaintingId);
            });
        },
        error: function (request, status, error) {
            console.log(request.responseText);
        }
    });
}
function createPainting(painting){
    console.log(painting);
    painting = JSON.stringify(painting); // javascript object to json
    console.log(painting);
    const url = `https://localhost:7146/api/PaintingModel`;
    $.ajax({
        url: url,
        type: 'POST',
        // dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: painting,
        success: function (data) {
            console.log(data);
        },
        error: function (request, status, error) {
            console.log(request.responseText);
        }
    });
}
function updatePainting(id,painting){
    painting = JSON.stringify(painting);
    const url = 'https://localhost:7146/api/PaintingModel/'+id;
    $.ajax({
        url: url,
        type:'UPDATE',
        contentType: "application/json; charset=utf-8",
        data: painting,
        success: function (data) {
            console.log(data);
        },
        error: function (request, status, error) {
            console.log(request.responseText);
            console.log({request, status, error})
            
        }
    });
}
function deletePainting(id){
    const url = 'https://localhost:7146/api/PaintingModel/'+id;
        Notiflix.Confirm.show(
            'Notiflix Confirm',
            'Do you agree with me?',
            'Yes',
            'No',
            function okCb() {
                $.ajax({
                    url: url,
                    type:'DELETE',
                    success: function (data) {
                        console.log(data);
                    },
                    error: function (request, status, error) {
                        console.log(request.responseText);
                        console.log({request, status, error})
                        
                    }
                });
            },
            function cancelCb() {
                alert('You can not delete.');
            },
            {
            },
        );
    // $.ajax({
    //     url: url,
    //     type:'DELETE',
    //     success: function (data) {
    //         console.log(data);
    //     },
    //     error: function (request, status, error) {
    //         console.log(request.responseText);
    //         console.log({request, status, error})
            
    //     }
    // });
}
function editPainting(id){
    const url = 'https://localhost:7146/api/PaintingModel/'+id;
    $.ajax({
        url:url,
        type:'GET',
        success:function(data){
            console.log(data);
        },
        error: function(request,status,error){
            console.log(request.responseText);
            console.log({request, status, error})
        }
    })
}
run()