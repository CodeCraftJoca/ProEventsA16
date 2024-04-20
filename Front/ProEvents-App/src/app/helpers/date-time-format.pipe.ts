import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from '../util/constants';

@Pipe({
  name: 'dateTimeFormatPipe'
})


export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

 // eslint-disable-next-line @typescript-eslint/no-unused-vars, @typescript-eslint/no-explicit-any
 override transform(value: any, args?: any): any {
  return super.transform(value, Constants.DATE_TIME);
}


}
