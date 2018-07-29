package com.nagp.productinspection.resources.product;

import com.nagp.productinspection.resources.product.dto.ProductDto;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/inspection/{inspectionId}/product")
public class ProductResource {

    @RequestMapping(method = RequestMethod.GET)
    @ResponseBody
    public List<ProductDto> getAllForInspection(@PathVariable("inspectionId") final int inspectionId) {
        final List<ProductDto> products = new ArrayList<>();
        products.add(new ProductDto(1, inspectionId, "Product 1"));
        products.add(new ProductDto(2, inspectionId, "Product 2"));
        return products;
    }

    @RequestMapping(method = RequestMethod.GET, path = "/{id}")
    public ProductDto getById(@PathVariable("id") final int id,
                              @PathVariable("inspectionId") final int inspectionId) {
        return new ProductDto(id, inspectionId, "Product 1");
    }

    @RequestMapping(method = RequestMethod.PUT, path = "/{id}")
    public void updateProduct(@PathVariable("id") final int id,
                              @PathVariable("inspectionId") final String inspectionId) {
        System.out.println("Update: ");
    }
}
