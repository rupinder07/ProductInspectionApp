package com.nagp.productinspection.resources.login.resources;

import com.nagp.productinspection.resources.login.dto.UserDto;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.URI;

@RestController
@RequestMapping("/login")
public class LoginResource {

    @RequestMapping(method = RequestMethod.POST)
    ResponseEntity<UserDto> login(@RequestBody final UserDto user) {
        if(user.getUsername().equals("nagp@nagarro.com") &&
                user.getPassword().equals("nagp")){
            return ResponseEntity.created(URI.create("/login")).build();
        }
        return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
    }

}
