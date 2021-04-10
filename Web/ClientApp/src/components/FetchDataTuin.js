import React, { Component } from 'react';

export class FetchDataTuin extends Component {
    static displayName = FetchDataTuin.name;

    constructor(props) {
        super(props);
        this.state = { makelaars: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderTable(makelaars, recordsProceeded, total) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th> records proceeded: {recordsProceeded}/{total}</th>
                        <th> </th>
                        <th> </th>
                    </tr>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Number of aanbods</th>

                    </tr>
                </thead>
                <tbody>
                    {makelaars.map(m =>
                        <tr key={m.makelaarId}>
                            <td>{m.makelaarId}</td>
                            <td>{m.name}</td>
                            <td>{m.numOfProposals}</td>

                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchDataTuin.renderTable(this.state.makelaars, this.state.recordsProceeded, this.state.totalRecords);

        return (
            <div>
                <h1 id="tabelLabel" >Makelaars (tuin)</h1>
                <p>This component demonstrates fetching makelaars that provide aanbods with tuin.</p>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('api/makellaar/top/tuin');
        const data = await response.json();
        this.setState({ makelaars: data.makelaars, recordsProceeded: data.recordsProceeded, totalRecords: data.totalRecords, loading: false });
    }
}
