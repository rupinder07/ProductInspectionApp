package com.nagp.productinspection.resources.inspections;

import com.nagp.productinspection.resources.inspections.dto.InspectionDto;
import com.nagp.productinspection.resources.inspections.dto.InspectionDtoBuilder;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

@RestController
public class InspectionResource {

    @GetMapping("/inspection")
    @ResponseBody
    public List<InspectionDto> getAll() {
        final List<InspectionDto> inspections = new ArrayList<>();
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(1,
                "Inspection 1",
                "Gurgaon",
                0L)
                .build());
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(2,
                "Inspection 2",
                "Noida",
                1L)
                .build());
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(3,
                "Inspection 3",
                "Delhi",
                2L)
                .build());
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(4,
                "Inspection 4",
                "Somewhere",
                3L)
                .build());
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(5,
                "Inspection 5",
                "Gurgaon",
                4L)
                .build());
        inspections.add(InspectionDtoBuilder.anInspectionDtoBuilder(6,
                "Inspection 6",
                "Gurgaon",
                5L)
                .build());
        return inspections;
    }

}
