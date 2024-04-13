import { Injectable } from "@angular/core";
import {History} from "./models"

@Injectable({
  providedIn: 'root'
})

export class DataService {
  public History: History[] = [];
}
