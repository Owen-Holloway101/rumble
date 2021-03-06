// =-= BEWARE HERE LIE DRAGONS, AUTH CONFIG IS COMPLETED HERE =-=
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { OAuthService } from "angular-oauth2-oidc";
import { Observable } from "rxjs"
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})

/*
* This service gets injected into the root app
*
* This allows for the auth token gathered through the oAuth Flow to be utilised and used to authenticate
* against the API service.
*
* */

export class AuthedHttpClientService implements HttpInterceptor {


  constructor(private oauthService: OAuthService, private router: Router){
    //The variable names here are a bit of a hack they need to be technically different, but I want them to be the same
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone( {
      setHeaders: {
        Authorization: `Bearer ${this.oauthService.getAccessToken()}`
      }
    });
    /*
    next.handle(request).subscribe(data => {},
      error => {
        switch (error.status) {
          case 401:
            console.log("Unauthorised");
            this.router.navigate(['/login']);
            break;
        }
      });
      */
    return next.handle(request);
  }


}
// =-= BEWARE HERE LIE DRAGONS, AUTH CONFIG IS COMPLETED HERE =-=
