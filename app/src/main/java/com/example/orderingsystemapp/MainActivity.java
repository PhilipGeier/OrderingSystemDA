package com.example.orderingsystemapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;



public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button = findViewById(R.id.make_request);
        TextView text = findViewById(R.id.text);

        button.setOnClickListener(view -> {
            Gson gson = new Gson();
        });
    }
}