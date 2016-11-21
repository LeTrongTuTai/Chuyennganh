var userGr = {
    init: function () {
        userGr.loadRole();
        userGr.registerEvent();
    },
    registerEvent: function () {
        $('.role').off('click').on('click', function () {
            userGr.loadData();
        });

        $("#select_all").change(function () {  //"select all" change 
            $(".mYcheckbox").prop('checked', $(this).prop("checked"));
            //change all ".checkbox" checked status
            userGr.loadData();
        });

        //".checkbox" change 
        $('.mYcheckbox').change(function () {
            //uncheck "select all", if one of the listed checkbox item is unchecked
            if (false == $(this).prop("checked")) { //if this item is unchecked
                $("#select_all").prop('checked', false); //change "select all" checked status to false
            }
            //check "select all" if all checkbox items are checked
            if ($('.mYcheckbox:checked').length == $('.mYcheckbox').length) {
                $("#select_all").prop('checked', true);
            }
            userGr.loadData();
        });
    },
    loadData: function () {
        var role = '';
        $(".mYcheckbox:checked").each(function () {
            role += $(this).val() + ",";
        });
        role = role.slice(0, -1);
        $('#txtRole').val(role);
    },
    loadRole: function () {
        var credential = ($('#credential').val()).split(",");
        for (i = 0; i < credential.length; i++) {
            $(".role input").each(function () {
                if ($(this).val() == credential[i]) {
                    $(this).attr("checked", 'checked');
                }
            });
        }
        $('#txtRole').val(credential);
    }
}
userGr.init();
