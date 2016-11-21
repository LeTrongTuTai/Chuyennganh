var productConfig = {
    pageSize: 12,
    pageIndex: 1,
    list: false,
}
var productAllController = {
    init: function () {
        productConfig.list = false;
        productAllController.loadData();
        productAllController.registerEvent();
    },
    registerEvent: function () {
        $('#SortBy').off('click').on('click', function (e) {
            e.preventDefault();
            if (productConfig.list == true) {
                productAllController.loadDataList(true);
            }
            else {
                productAllController.loadData(true);
            }
        });
        $('#list_view').off('click').on('click', function (e) {
            e.preventDefault();
            productConfig.list = false;
            productAllController.loadDataList(true);
        });
        $('#list_grid').off('click').on('click', function (e) {
            e.preventDefault();
            productConfig.list = true;
            productAllController.loadData(true);
        });

    },
    loadDataList: function (changePageSize) {
        productConfig.list = true;
        var sort = $('#SortBy').val();
        $.ajax({
            url: '/Produc/LoadDataAllMoi',
            type: 'GET',
            data: {
                sort: sort,
                page: productConfig.pageIndex,
                pageSize: productConfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template-list').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            sale: (item.PromotionPrice != null) ? true : false,
                            ProductImage: item.Image,
                            ProductName: item.Name,
                            ProductID: item.ID,
                            PromotionPrice: numeral(item.PromotionPrice).format('0,0'),
                            ProductPrice: numeral(item.Price).format('0,0'),
                            url: '/chi-tiet/' + item.Metatitle + '-' + item.ID + '.html',
                              ProductDescription:item.Description
                        });

                    });
                    if (html == '') {
                        $('#notfound_product').show();
                        $('#product_top').hide();
                        $('#grid_pagination').hide();
                    }
                    else {
                        $('#notfound_product').hide();
                        $('#product_top').show();
                        $('#grid_pagination').show();
                        $('#tblData').html(html);
                        $('.productCount').html('Có <span class="require_symbol">' + response.total + '</span> sản phẩm.');
                        productAllController.paging(response.total, function () {
                            productAllController.loadDataList();
                        }, changePageSize);
                    }
                    productAllController.registerEvent();
                }
            }
        })
    },
    loadData: function (changePageSize) {
        productConfig.list = false;
        var sort = $('#SortBy').val();
        $.ajax({
            url: '/Produc/LoadDataAllMoi',
            type: 'GET',
            data: {
                sort: sort,
                page: productConfig.pageIndex,
                pageSize: productConfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            sale: (item.PromotionPrice != null) ? true : false,
                            ProductImage: item.Image,
                            ProductName: item.Name,
                            ProductID: item.ID,
                            PromotionPrice: numeral(item.PromotionPrice).format('0,0'),
                            ProductPrice: numeral(item.Price).format('0,0'),
                            url: '/chi-tiet/' + item.Metatitle + '-' + item.ID + '.html'
                        });

                    });
                    if (html == '') {
                        $('#notfound_product').show();
                        $('#product_top').hide();
                        $('#grid_pagination').hide();
                    }
                    else {
                        $('#notfound_product').hide();
                        $('#product_top').show();
                        $('#grid_pagination').show();
                        $('#tblData').html(html);
                        $('.productCount').html('Có <span class="require_symbol">' + response.total + '</span> sản phẩm.');
                        productAllController.paging(response.total, function () {
                            productAllController.loadData();
                        }, changePageSize);
                    }
                    productAllController.registerEvent();
                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / productConfig.pageSize);
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }

        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "«",
            next: "›",
            last: "»",
            prev: "‹",
            visiblePages: 10,
            onPageClick: function (event, page) {
                productConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
productAllController.init();