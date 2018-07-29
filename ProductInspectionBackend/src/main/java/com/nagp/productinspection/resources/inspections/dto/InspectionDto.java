package com.nagp.productinspection.resources.inspections.dto;

import java.time.LocalDateTime;

public class InspectionDto {

    private int id;
    private String name;
    private String dueDate;
    private String location;
    private String lastSyncTime;

    public InspectionDto(final int id,
                         final String name,
                         final String dueDate,
                         final String location,
                         final String lastSyncTime) {
        this.id = id;
        this.name = name;
        this.dueDate = dueDate;
        this.location = location;
        this.lastSyncTime = lastSyncTime;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getDueDate() {
        return dueDate;
    }

    public String getLocation() {
        return location;
    }

    public String getLastSyncTime() {
        return lastSyncTime;
    }
}
