import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'customerStatus'})
export class СustomerStatusPipe implements PipeTransform {
  transform(value: number): string {
    switch(value){
        case 0:
            return "Prospective";
        case 1:
            return "Current";
        case 2:
            return "Non-active";
    }
  }
}