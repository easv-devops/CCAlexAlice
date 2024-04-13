import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { DataService } from 'src/data.service';
import {History} from "../../models"
import {ToastController } from '@ionic/angular';
@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(public toastController: ToastController, public fb: FormBuilder, public http: HttpClient, public dataService: DataService) {
    this.getHistory();
  }

  convert = this.fb.group({
    source: ['', [Validators.required]],
    target: ['', [Validators.required]],
    value: ['', [Validators.required]]
  })

  async getHistory() {
    const call = this.http.get<History[]>('http://localhost:5000/api/history');
    this.dataService.History = await firstValueFrom<History[]>(call);
  }

  async convertSubmit() {
      const observable = this.http.post<History>('http://localhost:5000/api/conversion', this.convert.getRawValue())
      const response = await firstValueFrom<History>(observable);
      console.log(response);
      this.dataService.History.push(response);

      const toast = await this.toastController.create({
        message: 'Conversion ready!',
        duration: 1233,
        color: "success"
      })
      toast.present();
  }
}
