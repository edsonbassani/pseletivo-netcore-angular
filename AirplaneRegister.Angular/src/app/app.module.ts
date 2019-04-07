import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AirplanesregisterComponent } from './airplanesregister/airplanesregister.component';
import { AirplaneregisterComponent } from './airplanesregister/airplaneregister/airplaneregister.component';
import { AirplaneregisterListComponent } from './airplanesregister/airplaneregister-list/airplaneregister-list.component';
import { AirplaneregisterService } from './shared/airplaneregister.service';

@NgModule({
  declarations: [
    AppComponent,
    AirplanesregisterComponent,
    AirplaneregisterComponent,
    AirplaneregisterListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [AirplaneregisterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
