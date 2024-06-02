import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ButtonComponent } from "../components/button/button.component";
import { InputComponent } from "../components/input/input.component";
import { DropdownComponent } from "../components/dropdown/dropdown.component";
import { AuthenticationModule } from "./authentication/authentication.module";

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    ButtonComponent,
    InputComponent,
    DropdownComponent,
    AppRoutingModule,
    AuthenticationModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}