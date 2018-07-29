package com.nagp.productinspection.resources.inspections.dto;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class InspectionDtoBuilder {

    private int id;
    private String name;
    private String location;
    private Long days;
    private LocalDateTime createdTime =
            LocalDateTime.of(2018, 7, 28, 22, 8);

    private DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");

    public static InspectionDtoBuilder anInspectionDtoBuilder(final int id,
                                                              final String name,
                                                              final String location,
                                                              final Long days){
        return new InspectionDtoBuilder(id, name, location, days);
    }

    public InspectionDtoBuilder(int id, String name, String location, Long days) {
        this.id = id;
        this.name = name;
        this.location = location;
        this.days = days;
    }

    public InspectionDto build(){
        return new InspectionDto(id,
                name,
                LocalDateTime.now().plusDays(days).format(dateTimeFormatter),
                location,
                createdTime.format(dateTimeFormatter));
    }
}
