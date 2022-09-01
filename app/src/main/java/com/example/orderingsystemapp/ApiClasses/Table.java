package com.example.orderingsystemapp.ApiClasses;

import java.util.List;
import java.util.UUID;

public class Table {
    private UUID Id;
    private String Label;
    private List<UUID> CurrentItems;
    private int Location;

    public UUID getId() {
        return Id;
    }

    public void setId(UUID id){
        Id = id;
    }

    public String getLabel() {
        return Label;
    }

    public void setLabel(String label) {
        Label = label;
    }

    public List<UUID> getCurrentItems() {
        return CurrentItems;
    }

    public void setCurrentItems(List<UUID> currentItems) {
        CurrentItems = currentItems;
    }

    public int getLocation() {
        return Location;
    }

    public void setLocation(int location) {
        Location = location;
    }
}
