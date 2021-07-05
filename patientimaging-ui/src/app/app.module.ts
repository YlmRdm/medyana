import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LogService } from './shared/log.service';
import { LogTestComponent } from './log-test/log-test-component';


@NgModule({
  declarations: [
    AppComponent,
    LogTestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [LogService],
  bootstrap: [AppComponent]
})
export class AppModule { }
